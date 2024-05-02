using System;

namespace RiskSystems.Objects.Exceptions
{
    public class TradeException : Exception
    {
        public int RowNumber { get; set; }
        public TradeException(int rowNumber) : base() {
            RowNumber = rowNumber;
         }

        public TradeException(string message, int rowNumber) : base(message) {
             RowNumber = rowNumber;
         }

        public TradeException(string message, Exception innerException) : base(message, innerException) { }
 
    }
}