using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Domain.Repositories;
using si730ebu201920124.API.Loyalty.Domain.services;
using si730ebu201920124.API.Loyalty.Domain.services.Communication;
using si730ebu201920124.API.Loyalty.Resources;
using si730ebu201920124.API.Shared.Domain.Repositories;

namespace si730ebu201920124.API.Loyalty.Services;

public class RewardService:IRewardService
{
    private readonly IRewardRepository _rewardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RewardService(IRewardRepository rewardRepository, IUnitOfWork unitOfWork)
    {
        _rewardRepository = rewardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Reward> GetByIdAsync(int id)
    {
        return await _rewardRepository.FindByIdAsync(id);
    }


    public async Task<IEnumerable<Reward>> ListAsync()
    {
        return await _rewardRepository.ListAsync();
    }


    public async Task<IEnumerable<Reward>> ListByScoreAsync(int score)
    {
        return await _rewardRepository.FindByScoreAsync(score);
    }


  


    public async Task<RewardResponse> SaveAsync(Reward reward, int fleeId)
    {

       

      


        var existingRewardWithName = await _rewardRepository.FindByNameAsync(reward.Name);
        var existingRewardWithFleeId = await _rewardRepository.FindByFleetIdAsync(fleeId);


        if ( existingRewardWithFleeId != null) {
            if (existingRewardWithName != null)
               return new RewardResponse("Reward name already has that fleed ID.");
        }
          

        if (reward.Score == 0 )
            return new RewardResponse("Score cannot be 0.");

    
        try
        {
       
            await _rewardRepository.AddAsync(reward, fleeId);

          
            await _unitOfWork.CompleteAsync();

            // Return response
            return new RewardResponse(reward);
        }
        catch (Exception e)
        {
            // Error handling
            return new RewardResponse($"An error occurred while saving the Reward: {e.Message}");
        }
    }

    
}
