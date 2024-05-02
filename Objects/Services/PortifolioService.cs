using System.Collections.Generic;
using System.Globalization;
using RiskFirstTest.Domain.Entites;
using RiskSystems.Objects.Domain;
using RiskSystems.Objects.Exceptions; 

namespace RiskSystems.Objects.Services
{
    public class PortfolioService
    {

        public bool Validate(List<string> lines)
        {
            if (lines.Count < 2)
            {
                throw new FileUnformattedException("File must have at least 2 lines");
            }

            if (!DateTime.TryParse(lines[0], out _))
            {
                throw new ReferenceDateException("Reference date must be a valid date");
            }

            if (!int.TryParse(lines[1], out int portfolioCount) || portfolioCount < 0)
            {
                throw new PortfolioCountException("Portfolio count must be a same number of defined portfolios");
            }

            return true;
        }

        public void ValidRow(List<string> trade, int rowNumber)
        {
            if (trade.Count < 2)
            {
                throw new TradeException($"Trade must have at least 3 values", rowNumber);
            }

            if (!double.TryParse(trade[0], out _) || double.Parse(trade[0]) < 0)
            {
                throw new TradeException($"Trade amount greather than or equals to 0", rowNumber);
            }

            if (trade[1] != "Private" && trade[1] != "Public")
            {
                throw new TradeException($"Trade client sector must be 'Private' or 'Public'", rowNumber);
            }

            if (!DateTime.TryParseExact(trade[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                throw new TradeException($"Trade date must be a valid date in the format 'mm/dd/yyyy'", rowNumber);
            }
             
        }


        public Portfolio CreatePotifolio(List<string> lines)
        {
            var portfolio = new Portfolio();
            Validate(lines);
            var trades = new List<Trade>(); 
            var referenceDate = DateTime.ParseExact(lines[0], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var portfolioCount = int.Parse(lines[1]);
            List<ICategorizationRule> rules = new List<ICategorizationRule>();
            rules.Add(new ExpiredRule(referenceDate));
            rules.Add(new HighRiskRule());
            rules.Add(new MediumRiskRule());
            var tradeClassifierService = new TradeService(rules);
            for (int i = 2; i < portfolioCount + 2; i++)
            {
                var tradeLine = lines[i].Split(' ').ToList();
                var trade = AddTrade(tradeLine, i);                
                tradeClassifierService.ClassifyTrade(trade);
                trades.Add(trade);               
            }

            portfolio.Trades = trades;
            portfolio.ReferenceDate = referenceDate;
            portfolio.NumberOfTrades = portfolioCount;
            return portfolio;
        }
        public Trade AddTrade(List<string> tradeLine, int rowNumber)
        {
            ValidRow(tradeLine, rowNumber);
            var tradeValue = double.Parse(tradeLine[0]);
            var tradeClientSector = tradeLine[1];
            var tradeNextPaymentDate = DateTime.ParseExact(tradeLine[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var trade = new Trade(tradeValue, tradeClientSector, tradeNextPaymentDate);
            return trade;
        }
    }





}