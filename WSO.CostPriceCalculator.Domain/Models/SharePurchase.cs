using System;

namespace WSO.CostPriceCalculator.Domain.Models
{
    public struct SharePurchase
    {
        public DateTime PurchaseDate { get; private set; }

        /// <summary>
        /// The number of shares purchased
        /// (Have assumed fractional shares are out of scope)
        /// </summary>
        public int Quantity { get; private set; }

        public decimal PricePerShare { get; private set; }

        public SharePurchase(DateTime purchaseDate, int numberOfShares, decimal pricePerShare)
        {
            this.PurchaseDate = purchaseDate;
            this.Quantity = numberOfShares;
            this.PricePerShare = pricePerShare;
        }
    }
}
