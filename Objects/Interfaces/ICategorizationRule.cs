using RiskFirstTest.Domain.Entites;

public interface ICategorizationRule
{
    bool IsApplicable(ITrade trade);
    TradeCategory DetermineCategory();
}
