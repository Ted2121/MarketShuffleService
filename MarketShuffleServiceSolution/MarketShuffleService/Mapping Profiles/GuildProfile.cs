using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class GuildProfile : Profile
{
    public GuildProfile()
    {
        CreateMap<Guild, GuildDto>().ReverseMap();
    }
}
