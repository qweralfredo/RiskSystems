using RiskFirstTest.Domain.Entites;

public class ExpiredRule : ICategorizationRule 
{
   private readonly DateTime _referenceDate;
   public ExpiredRule(DateTime referenceDate) {
       _referenceDate = referenceDate;
   }

    public TradeCategory DetermineCategory()
    {
        return TradeCategory.EXPIRED;
    }

    public bool IsApplicable(ITrade trade)
    {
        var days = (trade.NextPaymentDate - _referenceDate).TotalDays;
        return  days < 30;
       
    }
}