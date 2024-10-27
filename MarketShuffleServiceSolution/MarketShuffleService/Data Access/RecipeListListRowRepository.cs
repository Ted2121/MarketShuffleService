using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public class RecipeListListRowRepository : IRecipeItemRepository
{
    public Task<string> CreateRecipeItemAsync(RecipeItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRecipeItemAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecipeItem>> GetAllRecipeItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecipeItem>> GetAllRecipeItemsByParentId(string id)
    {
        throw new NotImplementedException();
    }

    public Task<RecipeItem> GetRecipeItemByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRecipeItemAsync(RecipeItem item)
    {
        throw new NotImplementedException();
    }
}
