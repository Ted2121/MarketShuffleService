using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class RecipeItemRepository : IRecipeItemRepository
{
    private readonly AppDbContext _appDbContext;

    public RecipeItemRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreateRecipeItemAsync(RecipeItem recipeItem)
    {
        if (recipeItem == null)
        {
            throw new ArgumentNullException(nameof(recipeItem));
        }

        try
        {
            await _appDbContext.AddAsync(recipeItem);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return recipeItem.Id;
            }
            else
            {
                throw new Exception($"recipeItem with id: {recipeItem.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"recipeItem with id: {recipeItem.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<bool> DeleteRecipeItemAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var recipeItem =
            _appDbContext.RecipeItems.FirstOrDefault(x => x.Id == id);

            if (recipeItem == null)
            {
                return false;
            }

            _appDbContext.Remove<RecipeItem>(recipeItem);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete recipeItem with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<RecipeItem>> GetAllRecipeItemsAsync()
    {
        try
        {
            return await _appDbContext.RecipeItems.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all recipeItems. Exception was: {ex.Message}");
        }
    }

    public async Task<IEnumerable<RecipeItem>> GetAllRecipeItemsByParentId(string id)
    {
        try
        {
            return await _appDbContext.RecipeItems.Where(x => x.ParentItemId == id).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all recipeItems. Exception was: {ex.Message}");
        }
    }

    public async Task<RecipeItem> GetRecipeItemByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.RecipeItems.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting recipeItem with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdateRecipeItemAsync(RecipeItem recipeItem)
    {
        if (recipeItem == null)
        {
            throw new ArgumentNullException("recipeItem was null");
        }

        try
        {

            var recipeItemToUpdate = await _appDbContext.FindAsync<RecipeItem>(recipeItem.Id);

            if (recipeItemToUpdate == null)
            {
                throw new Exception($"recipeItem with id: {recipeItem.Id} was not found");
            }

            recipeItemToUpdate.Name = recipeItem.Name;
            recipeItemToUpdate.Quantity = recipeItem.Quantity;

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating recipeItem with id: {recipeItem.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }
}
