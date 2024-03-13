using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayerDto>().ReverseMap();
    }
}
