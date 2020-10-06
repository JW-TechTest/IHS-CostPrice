using System;
using System.Collections.Generic;
using System.Linq;
using WSO.CostPriceCalculator.Domain.Enums;

namespace WSO.CostPriceCalculator.Domain.Models
{
    public class SharePortfolio
    {
        private List<SharePurchase> _sharePurchases = new List<SharePurchase>();
        public IReadOnlyCollection<SharePurchase> SharePurchases => _sharePurchases.ToList();

        /// <summary>
        /// The cost price of the currently held / remaining shares
        /// </summary>
        public decimal CostPrice => CalculateWeightedAverageCostPrice(_sharePurchases);

        public int NumberOfSharesOwned => _sharePurchases.Sum(sp => sp.Quantity);

        public void PurchaseShares(DateTime purchaseDate, int numberOfShares, decimal pricePerShare)
        {
            // TODO: Add domain validation
            _sharePurchases.Add(new SharePurchase(purchaseDate, numberOfShares, pricePerShare));
        }

        /// <summary>
        /// Sells shares currently in the portfolio and returns the cost price and profit/loss of the sold shares
        /// </summary>
        /// <param name="sellDate">The date the shares were sold</param>
        /// <param name="numberOfSharesSold">The number of shares sold</param>
        /// <param name="sellPrice">The price at which each share was sold for</param>
        /// <param name="costMethod">The method used to calculate cost price</param>
        /// <returns>The cost price and gain/loss of the sold shares determined by the cost method</returns>
        public SaleResult SellShares(DateTime sellDate, int numberOfSharesSold, decimal sellPrice, CostMethod costMethod)
        {
            if (numberOfSharesSold > this.NumberOfSharesOwned)
            {
                throw new DomainValidationException("There are not enough shares in the portfolio to cover this sale.");
            }

            if (sellPrice < 0)
            {
                throw new DomainValidationException("Sell price cannot be negative.");
            }

            IEnumerable<SharePurchase> orderedPurchases = OrderSharesByCostMethod(_sharePurchases, costMethod);
            orderedPurchases = FilterSharesBySellDate(sellDate, numberOfSharesSold, orderedPurchases);

            List<SharePurchase> sharesSold = DetermineSharesToSell(sellDate, numberOfSharesSold, orderedPurchases);

            if (costMethod == CostMethod.WeightedAverage)
            {
                decimal costPrice = CalculateWeightedAverageCostPrice(orderedPurchases);
                decimal delta = sellPrice - costPrice;

                return new SaleResult(costPrice, delta);
            }
            else
            {
                decimal costPrice = sharesSold.Sum(s => s.Quantity * s.PricePerShare) / numberOfSharesSold;
                decimal delta = sharesSold.Sum(s => s.Quantity * (sellPrice - s.PricePerShare));

                return new SaleResult(costPrice, delta);
            }
        }

        /// <summary>
        /// Finds the shares to sell based on the sell date and the number of shares sold
        /// </summary>
        /// <param name="sellDate"></param>
        /// <param name="numberOfSharesSold"></param>
        /// <param name="orderedSharePurchases">A priority ordered list of shares to use to cover the sale</param>
        /// <returns>A list of the shares sold</returns>
        private List<SharePurchase> DetermineSharesToSell(DateTime sellDate, int numberOfSharesSold, IEnumerable<SharePurchase> orderedSharePurchases)
        {
            var sharesSold = new List<SharePurchase>();
            var sharesRemaining = new List<SharePurchase>();

            // Build a list of share purchases that we've sold entirely and one of shares we've only partially sold
            foreach (var sharePurchase in orderedSharePurchases)
            {
                int numberOfSharesSoldSoFar = sharesSold.Sum(s => s.Quantity);
                int numberOfSharesToSell = Math.Min(numberOfSharesSold - numberOfSharesSoldSoFar, sharePurchase.Quantity);
                if (numberOfSharesToSell == sharePurchase.Quantity)
                {
                    sharesSold.Add(sharePurchase);
                }
                else
                {
                    sharesRemaining.Add(new SharePurchase(
                            sharePurchase.PurchaseDate,
                            sharePurchase.Quantity - numberOfSharesToSell,
                            sharePurchase.PricePerShare
                        ));

                    sharesSold.Add(new SharePurchase(
                            sharePurchase.PurchaseDate,
                            numberOfSharesToSell,
                            sharePurchase.PricePerShare
                        ));
                }
            }

            // Add the shares that we filtered out due to the sell date back
            var excludedPurchases = _sharePurchases.Where(s => s.PurchaseDate > sellDate).ToList();
            sharesRemaining.AddRange(excludedPurchases);
            _sharePurchases = sharesRemaining.ToList();

            return sharesSold;
        }

        /// <summary>
        /// Filters out shares that were purchased AFTER the supplied sell date
        /// This is an assumption as the document didn't state what to do with this, only that it existed
        /// </summary>
        /// <param name="sellDate"></param>
        /// <param name="numberOfSharesToSell"></param>
        /// <param name="orderedSharePurchases"></param>
        /// <returns>A list of share purchases that were before the supplied date</returns>
        private static IEnumerable<SharePurchase> FilterSharesBySellDate(DateTime sellDate, int numberOfSharesToSell, IEnumerable<SharePurchase> orderedSharePurchases)
        {
            orderedSharePurchases = orderedSharePurchases.Where(s => s.PurchaseDate <= sellDate).ToList();

            if (orderedSharePurchases.Sum(sp => sp.Quantity) < numberOfSharesToSell)
            {
                throw new DomainValidationException("There are not enough shares in the portfolio to cover this sale. Please try a different sell date.");
            }

            return orderedSharePurchases;
        }

        private decimal CalculateWeightedAverageCostPrice(IEnumerable<SharePurchase> shares)
        {
            return shares.Any() ? shares.Sum(s => s.Quantity * s.PricePerShare) / shares.Sum(s => s.Quantity) : 0;
        }

        private IEnumerable<SharePurchase> OrderSharesByCostMethod(IEnumerable<SharePurchase> shares, CostMethod costMethod)
        {
            switch (costMethod)
            {
                case CostMethod.WeightedAverage: // NOTE: It's not stated which shares should be used to cover a sale when using the WA cost method
                case CostMethod.FIFO:
                    return shares.OrderBy(s => s.PurchaseDate);
                case CostMethod.LIFO:
                    return shares.OrderByDescending(s => s.PurchaseDate);
                case CostMethod.HighestCost:
                    return shares.OrderByDescending(s => s.PricePerShare);
                case CostMethod.LowestCost:
                    return shares.OrderBy(s => s.PricePerShare);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
