using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class ItemPositionProfile : Profile
{
    public ItemPositionProfile()
    {
        CreateMap<ItemPosition, ItemPositionDto>().ReverseMap();
    }
}
