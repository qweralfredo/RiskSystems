using RiskFirstTest.Domain.Entites;

public class HighRiskRule : ICategorizationRule 
{ 
    public TradeCategory DetermineCategory()
    {
        return TradeCategory.HIGHRISK;
    }

    public bool IsApplicable(ITrade trade)
    {   
        return (trade.Value > 1000000 && trade.ClientSector == "Private" );
    }
}