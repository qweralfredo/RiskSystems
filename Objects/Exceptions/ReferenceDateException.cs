using System;

namespace RiskSystems.Objects.Exceptions
{
    public class ReferenceDateException : Exception
    {
        public ReferenceDateException() { }

        public ReferenceDateException(string message) : base(message) { }

        public ReferenceDateException(string message, Exception innerException) : base(message, innerException) { }
 
    }
}