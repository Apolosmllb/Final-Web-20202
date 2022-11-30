using AutoMapper;
using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Loyalty.Resources;

namespace si730ebu201920124.API.Loyalty.Mapping;
public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Reward, RewardResource>();
    }
}
