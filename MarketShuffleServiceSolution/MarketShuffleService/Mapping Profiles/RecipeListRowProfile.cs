using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class RecipeListRowProfile : Profile
{
    public RecipeListRowProfile()
    {
        CreateMap<RecipeListRow, RecipeListRowDto>().ReverseMap();
    }
}
