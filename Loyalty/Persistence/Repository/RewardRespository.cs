using Microsoft.EntityFrameworkCore;
using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Domain.Repositories;
using si730ebu201920124.API.Shared.Persistence.Contexts;
using si730ebu201920124.API.Shared.Persistence.Repositories;

namespace si730ebu201920124.API.Loyalty.Persistence.Repository;

public class RewardRespository:BaseRepository, IRewardRepository
{
    public RewardRespository(AppDbContext context) : base(context)
    {
    }

        public async Task<IEnumerable<Reward>> ListAsync()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<IEnumerable<Reward>> FindByScoreAsync(int score)
        {
            return await _context.Rewards.Where(p => p.Score >= score).ToListAsync();
        }

         public async Task<Reward> FindByFleetIdAsync(int fleetId)
          {
                return await _context.Rewards.FirstOrDefaultAsync(p => p.fleetId == fleetId);
          }



    public async Task AddAsync(Reward reward, int i)
        {
            reward.fleetId= i; 
            await _context.Rewards.AddAsync(reward);
        }

        public async Task<Reward> FindByIdAsync(int id)
        {
            return await _context.Rewards.FindAsync(id);
        }

        public async Task<Reward> FindByNameAsync(string name)
        {
            return await _context.Rewards
              .FirstOrDefaultAsync(p => p.Name == name);
        }

    
}
