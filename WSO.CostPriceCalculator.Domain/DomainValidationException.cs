using System;

namespace WSO.CostPriceCalculator.Domain
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {
        }
    }
}
