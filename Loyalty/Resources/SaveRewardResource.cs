using System.ComponentModel.DataAnnotations;

namespace si730ebu201920124.API.Loyalty.Resources;

public class SaveRewardResource
{
   

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public Decimal Score { get; set; }
}
