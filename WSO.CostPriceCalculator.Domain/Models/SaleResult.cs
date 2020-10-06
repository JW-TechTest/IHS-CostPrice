namespace WSO.CostPriceCalculator.Domain.Models
{
    public struct SaleResult
    {
        public decimal CostPrice { get; private set; }
        public decimal GainLoss { get; private set; }

        public SaleResult(decimal costPrice, decimal gainLoss)
        {
            this.CostPrice = costPrice;
            this.GainLoss = gainLoss;
        }
    }
}
