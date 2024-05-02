using RiskFirstTest.Domain.Entites;

public class MediumRiskRule : ICategorizationRule 
{ 
    public TradeCategory DetermineCategory()
    {
        return TradeCategory.MEDIUMRISK;
    }

    public bool IsApplicable(ITrade trade)
    {
        return (trade.Value > 1000000 && trade.ClientSector == "Public" );
    }
}