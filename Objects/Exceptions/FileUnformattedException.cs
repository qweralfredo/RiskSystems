using System;

namespace RiskSystems.Objects.Exceptions
{
    public class FileUnformattedException : Exception
    {
        public FileUnformattedException() { }

        public FileUnformattedException(string message) : base(message) { }

        public FileUnformattedException(string message, Exception innerException) : base(message, innerException) { }
 
    }
}