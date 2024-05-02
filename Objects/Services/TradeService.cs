using RiskFirstTest.Domain.Entites;

public class TradeService
{
    private readonly List<ICategorizationRule> _rules;

    public TradeService(List<ICategorizationRule> rules)
    {
        _rules = rules;
    }
 
    
    public void ClassifyTrade(ITrade trade)
    {
        trade.Category = TradeCategory.MEDIUMRISK;
        foreach (var rule in _rules)
        {
            if (rule.IsApplicable(trade))
            {
                trade.Category = rule.DetermineCategory();
                break;
            }
        }
    }
}