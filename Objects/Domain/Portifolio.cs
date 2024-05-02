using System;
using System.Collections.Generic;
using RiskFirstTest.Domain.Entites;

namespace RiskSystems.Objects.Domain
{
    public class Portfolio
    {
        public DateTime ReferenceDate { get; set; }
        public int NumberOfTrades { get; set; }
        public List<Trade> Trades { get; set; }

        public Portfolio()
        {
            
        }
        
        public Portfolio(DateTime referenceDate, int numberOfTrades, List<Trade> trades)
        {
            ReferenceDate = referenceDate;
            NumberOfTrades = numberOfTrades;
            Trades = trades;
        }

         

       
    } 
}