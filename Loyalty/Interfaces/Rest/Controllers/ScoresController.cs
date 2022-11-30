using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Domain.services;
using si730ebu201920124.API.Loyalty.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace si730ebu201920124.API.Loyalty.Interfaces.Rest.Controller;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read Providers")]
public class ScoresController
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;

    public ScoresController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }

    [HttpGet("{score:int}/rewards")]
    public async Task<IEnumerable<RewardResource>> GetAllByScoredAsync(int score)
    {
        var rewards = await _rewardService.ListByScoreAsync(score);

        var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(rewards);
        return resources;
    }

}
