using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IRecipeListRowRepository
{
    //Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsAsync();
    Task<RecipeListRow> GetRecipeListRowByIdAsync(string id);
    Task<string> CreateRecipeListRowAsync(RecipeListRow row);
    Task<bool> UpdateRecipeListRowAsync(RecipeListRow row);
    Task<bool> DeleteRecipeListRowAsync(string id);
    Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByRecipeListId(string resourceListId);
    Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByResourceName(string resourceName);
    //Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByResourceNameFromResourceList(string resourceName, string resourceListId);

}
