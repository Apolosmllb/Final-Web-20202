namespace si730ebu201920124.API.Loyalty.Domain.Models;

public class Reward
{
    public int Id { get; set; }
    public int fleetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Score { get; set; }

}
