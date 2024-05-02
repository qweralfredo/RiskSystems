using System;

namespace RiskSystems.Objects.Exceptions
{
    public class PortfolioCountException : Exception
    {
        public PortfolioCountException() { }

        public PortfolioCountException(string message) : base(message) { }

        public PortfolioCountException(string message, Exception innerException) : base(message, innerException) { }
 
    }
}