using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Domain.services;
using si730ebu201920124.API.Loyalty.Resources;
using si730ebu201920124.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace si730ebu201920124.API.Loyalty.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Creat Rewards")]
public class FleetsController: ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;

    public FleetsController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }


    [HttpPost("{fleetId:int}/rewards")]
    public async Task<IActionResult> PostAsync([FromBody] SaveRewardResource resource, int fleetId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var reward = _mapper.Map<SaveRewardResource, Reward>(resource);

        var result = await _rewardService.SaveAsync(reward,fleetId);

        if (!result.Success)
            return BadRequest(result.Message);

        var providerResource = _mapper.Map<Reward, RewardResource>(result.Resource);

        return Created(nameof(PostAsync), providerResource);
    }


}
