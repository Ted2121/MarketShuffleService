using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class RecipeItemProfile : Profile
{
	public RecipeItemProfile()
	{
        CreateMap<RecipeItem, RecipeItemDto>().ReverseMap();

    }
}
