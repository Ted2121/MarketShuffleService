using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IRecipeListRepository
{
    Task<IEnumerable<RecipeList>> GetAllRecipeListsAsync();
    Task<RecipeList> GetRecipeListByIdAsync(string id);
    Task<RecipeList> GetRecipeListByNameAsync(string name);
    Task<string> CreateRecipeListAsync(RecipeList recipeList);
    Task<bool> UpdateRecipeListAsync(RecipeList recipeList);
    Task<bool> DeleteRecipeListAsync(string id);
    Task<IEnumerable<RecipeList>> SearchRecipeListByName(string searchString);
    Task<IEnumerable<RecipeListRow>> Get

}
