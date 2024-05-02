namespace RiskFirstTest.Domain.Entites;
public interface ITrade 
{
    public double Value { get; set; }
    public string ClientSector { get; set; }
    public DateTime NextPaymentDate { get; set; }    
    public TradeCategory Category { get; set; }
}