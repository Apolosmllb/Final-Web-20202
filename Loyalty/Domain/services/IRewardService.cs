using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Domain.services.Communication;

namespace si730ebu201920124.API.Loyalty.Domain.services;

public interface IRewardService
{
    Task<IEnumerable<Reward>> ListAsync();
    Task<Reward> GetByIdAsync(int id);
    Task<RewardResponse> SaveAsync(Reward reward, int i);

    Task<IEnumerable<Reward>> ListByScoreAsync(int score);
}
