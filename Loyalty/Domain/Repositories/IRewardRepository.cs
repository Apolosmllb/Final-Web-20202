using si730ebu201920124.API.Loyalty.Domain.Models;

namespace si730ebu201920124.API.Loyalty.Domain.Repositories;

public interface IRewardRepository
{
    Task<IEnumerable<Reward>> ListAsync();
    Task AddAsync(Reward reward, int i);

    Task<Reward> FindByNameAsync(string name);
    Task<Reward> FindByIdAsync(int id);

    Task<Reward> FindByFleetIdAsync(int fleetId);

    Task<IEnumerable<Reward>> FindByScoreAsync(int score);
}
