using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IRecipeItemRepository
{
    Task<IEnumerable<RecipeItem>> GetAllRecipeItemsAsync();
    Task<Item> GetRecipeItemByIdAsync(string id);
    Task<string> CreateRecipeItemAsync(RecipeItem item);
    Task<bool> UpdateRecipeItemAsync(RecipeItem item);
    Task<bool> DeleteRecipeItemAsync(string id);
}
