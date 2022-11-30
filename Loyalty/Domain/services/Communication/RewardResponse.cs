using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Shared.Domain.Services.Communication;

namespace si730ebu201920124.API.Loyalty.Domain.services.Communication;

public class RewardResponse:BaseResponse<Reward>
{
    public RewardResponse(string message) : base(message)
    {
    }

    public RewardResponse(Reward resource) : base(resource)
    {
    }
}
