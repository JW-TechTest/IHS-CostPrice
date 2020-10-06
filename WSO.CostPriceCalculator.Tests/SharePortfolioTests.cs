using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WSO.CostPriceCalculator.Domain.Enums;
using WSO.CostPriceCalculator.Domain.Models;

namespace WSO.CostPriceCalculator.Domain.Tests
{
    [TestClass]
    public class SharePortfolioTests
    {

        #region NumberOfSharesOwned Tests
        [TestMethod]
        public void SharePortfolio_NumberOfSharesOwned_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 1.0m);
            Assert.AreEqual(2, sharePortfolio.NumberOfSharesOwned);

            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 1.4m);

            Assert.AreEqual(4, sharePortfolio.NumberOfSharesOwned);

            sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.FIFO);
            Assert.AreEqual(3, sharePortfolio.NumberOfSharesOwned);

            sharePortfolio.SellShares(DateTime.Now, 2, 1m, CostMethod.FIFO);
            Assert.AreEqual(1, sharePortfolio.NumberOfSharesOwned);
        }

        [TestMethod]
        public void SharePortfolio_NumberOfSharesOwned_NoSharesOwned_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();

            Assert.AreEqual(0, sharePortfolio.NumberOfSharesOwned);

            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 0, 1.0m);

            Assert.AreEqual(0, sharePortfolio.NumberOfSharesOwned);
        }

        #endregion

        #region CostPrice Tests

        [TestMethod]
        public void SharePortfolio_CostPrice_NoShares_Should_NotThrowException()
        {
            var sharePortfolio = new SharePortfolio();
            Assert.AreEqual(0m, sharePortfolio.NumberOfSharesOwned);
            Assert.AreEqual(0m, sharePortfolio.CostPrice);
        }

        [TestMethod]
        public void SharePortfolio_CostPrice_SellAllShares_Should_NotThrowException()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 5, 1m);
            var saleResults = sharePortfolio.SellShares(DateTime.Now, 5, 1m, CostMethod.FIFO);

            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(0m, saleResults.GainLoss);
            Assert.AreEqual(0m, sharePortfolio.NumberOfSharesOwned);
            Assert.AreEqual(0m, sharePortfolio.CostPrice);
        }

        #endregion

        #region SellShares Tests

        [TestMethod]
        public void SharePortfolio_SellShares_FIFO_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 0.5m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 0.7m);

            Assert.AreEqual(0.6m, sharePortfolio.CostPrice);

            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0.75m, CostMethod.FIFO);
            Assert.AreEqual(0.5m, saleResults.CostPrice);
            Assert.AreEqual(0.25m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_FIFO_ExampleSolution_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2005, 1, 1), 100, 10m);
            sharePortfolio.PurchaseShares(new DateTime(2005, 2, 2), 40, 12m);
            sharePortfolio.PurchaseShares(new DateTime(2005, 3, 3), 50, 11m);

            Assert.AreEqual(190, sharePortfolio.NumberOfSharesOwned);

            var saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 2), 120, 10.5m, CostMethod.FIFO);
            Assert.AreEqual(10.333333333333333333333333333m, saleResults.CostPrice);
            Assert.AreEqual(20m, saleResults.GainLoss);
            Assert.AreEqual(11.285714285714285714285714286m, sharePortfolio.CostPrice);
            Assert.AreEqual(70, sharePortfolio.NumberOfSharesOwned);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_LIFO_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 0.5m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 0.7m);

            Assert.AreEqual(0.6m, sharePortfolio.CostPrice);

            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0.75m, CostMethod.LIFO);
            Assert.AreEqual(0.7m, saleResults.CostPrice);
            Assert.AreEqual(0.05m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_WeightedAverage_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 0.5m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 0.7m);

            Assert.AreEqual(0.6m, sharePortfolio.CostPrice);

            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0.75m, CostMethod.WeightedAverage);
            Assert.AreEqual(0.6m, saleResults.CostPrice);
            Assert.AreEqual(0.15m, saleResults.GainLoss);

            saleResults = sharePortfolio.SellShares(DateTime.Now, 2, 1m, CostMethod.WeightedAverage);
            Assert.AreEqual(0.6333333333333333333333333333m, saleResults.CostPrice);
            Assert.AreEqual(0.3666666666666666666666666667m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_HighestCost_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 0.5m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 0.7m);

            Assert.AreEqual(0.6m, sharePortfolio.CostPrice);

            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0.8m, CostMethod.HighestCost);
            Assert.AreEqual(0.7m, saleResults.CostPrice);
            Assert.AreEqual(0.1m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_LowestCost_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 2, 0.5m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 2), 2, 0.7m);

            Assert.AreEqual(0.6m, sharePortfolio.CostPrice);

            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.LowestCost);
            Assert.AreEqual(0.5m, saleResults.CostPrice);
            Assert.AreEqual(0.5m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_NoShares_Should_ThrowDomainException()
        {
            var sharePortfolio = new SharePortfolio();

            var exception = Assert.ThrowsException<DomainValidationException>(
                    () => sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.FIFO)
                );

            Assert.AreEqual("There are not enough shares in the portfolio to cover this sale.", exception.Message);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_NegativeSellPrice_Should_ThrowDomainException()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);

            var exception = Assert.ThrowsException<DomainValidationException>(
                    () => sharePortfolio.SellShares(DateTime.Now, 1, -1m, CostMethod.FIFO)
                );

            Assert.AreEqual("Sell price cannot be negative.", exception.Message);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_SellMoreSharesThanOwned_Should_ThrowDomainException()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 50, 1m);

            var exception = Assert.ThrowsException<DomainValidationException>(
                    () => sharePortfolio.SellShares(DateTime.Now, 51, 1m, CostMethod.FIFO)
                );

            Assert.AreEqual("There are not enough shares in the portfolio to cover this sale.", exception.Message);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_SellSharesAtALoss_Should_CalculateGainLossCorrectly()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 100, 2m);

            // FIFO Test
            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.FIFO);
            Assert.AreEqual(2m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // LIFO Test
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.LIFO);
            Assert.AreEqual(2m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // HighestCost Test
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.HighestCost);
            Assert.AreEqual(2m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // LowestCost Test
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.LowestCost);
            Assert.AreEqual(2m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // WeightedAverage Test
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 1m, CostMethod.WeightedAverage);
            Assert.AreEqual(2m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_SellSharesForFree_Should_CalculateGainLossCorrectly()
        {
            var sharePortfolio = new SharePortfolio();

            // FIFO Test
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);
            var saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0, CostMethod.FIFO);
            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // LIFO Test
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0, CostMethod.LIFO);
            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // HighestCost Test
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0, CostMethod.HighestCost);
            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // LowestCost Test
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0, CostMethod.LowestCost);
            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);

            // WeightedAverage Test
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 1, 1m);
            saleResults = sharePortfolio.SellShares(DateTime.Now, 1, 0, CostMethod.WeightedAverage);
            Assert.AreEqual(1m, saleResults.CostPrice);
            Assert.AreEqual(-1m, saleResults.GainLoss);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_ChainingSales_Should_ReturnCorrectValue()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2005, 1, 1), 100, 10m);
            sharePortfolio.PurchaseShares(new DateTime(2005, 2, 2), 40, 12m);
            sharePortfolio.PurchaseShares(new DateTime(2005, 3, 3), 50, 11m);

            Assert.AreEqual(190, sharePortfolio.NumberOfSharesOwned);

            var saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 2), 120, 10.5m, CostMethod.FIFO);
            Assert.AreEqual(10.333333333333333333333333333m, saleResults.CostPrice);
            Assert.AreEqual(20m, saleResults.GainLoss);
            Assert.AreEqual(11.285714285714285714285714286m, sharePortfolio.CostPrice);
            Assert.AreEqual(70, sharePortfolio.NumberOfSharesOwned);

            saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 3), 10, 13.2m, CostMethod.LIFO);
            Assert.AreEqual(11m, saleResults.CostPrice);
            Assert.AreEqual(22m, saleResults.GainLoss);
            Assert.AreEqual(11.333333333333333333333333333m, sharePortfolio.CostPrice);
            Assert.AreEqual(60, sharePortfolio.NumberOfSharesOwned);

            saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 3), 25, 10m, CostMethod.HighestCost);
            Assert.AreEqual(11.8m, saleResults.CostPrice);
            Assert.AreEqual(-45m, saleResults.GainLoss);
            Assert.AreEqual(11, sharePortfolio.CostPrice);
            Assert.AreEqual(35, sharePortfolio.NumberOfSharesOwned);

            saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 3), 5, 11m, CostMethod.WeightedAverage);
            Assert.AreEqual(11m, saleResults.CostPrice);
            Assert.AreEqual(0m, saleResults.GainLoss);
            Assert.AreEqual(11, sharePortfolio.CostPrice);
            Assert.AreEqual(30, sharePortfolio.NumberOfSharesOwned);

            saleResults = sharePortfolio.SellShares(new DateTime(2005, 3, 3), 30, 12m, CostMethod.LowestCost);
            Assert.AreEqual(11m, saleResults.CostPrice);
            Assert.AreEqual(30m, saleResults.GainLoss);
            Assert.AreEqual(0, sharePortfolio.CostPrice);
            Assert.AreEqual(0, sharePortfolio.NumberOfSharesOwned);
        }

        [TestMethod]
        public void SharePortfolio_SellShares_ThatHaveNotBeenPurchasedYet_Should_ThrowDomainException()
        {
            var sharePortfolio = new SharePortfolio();
            sharePortfolio.PurchaseShares(new DateTime(2020, 1, 1), 100, 10m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 2, 2), 100, 15m);
            sharePortfolio.PurchaseShares(new DateTime(2020, 3, 3), 100, 20m);

            var exception = Assert.ThrowsException<DomainValidationException>(
                () => sharePortfolio.SellShares(new DateTime(2020, 2, 2), 300, 10.5m, CostMethod.FIFO)
            );

            Assert.AreEqual("There are not enough shares in the portfolio to cover this sale. Please try a different sell date.", exception.Message);
        }

        #endregion
    }
}
