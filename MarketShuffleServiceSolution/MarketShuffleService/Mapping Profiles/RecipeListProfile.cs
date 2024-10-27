using AutoMapper;
using MarketShuffleModels;
using MarketShuffleService.DTOs;

namespace MarketShuffleService.Mapping_Profiles;

public class RecipeListProfile: Profile
{
    public RecipeListProfile()
    {
        CreateMap<RecipeList, RecipeListDto>().ReverseMap();
    }
}
