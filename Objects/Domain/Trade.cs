
using RiskFirstTest.Domain.Entites;
namespace RiskFirstTest.Domain.Entites;

public class Trade : ITrade
{
    private Trade()
    {

    }
    public Trade(double value, string clientSector, DateTime nextPaymentDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDate = nextPaymentDate; 
    }

    public double Value { get; set; }
    public string ClientSector { get; set; }
    public DateTime NextPaymentDate { get; set; }
     public TradeCategory Category { get;  set; }
 
}
