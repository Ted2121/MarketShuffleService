using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();

    }
}
