using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class RecipeListRepository : IRecipeListRepository
{
    private readonly AppDbContext _appDbContext;

    public RecipeListRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<string> CreateRecipeListAsync(RecipeList recipeList)
    {
        if (recipeList == null)
        {
            throw new ArgumentNullException(nameof(recipeList));
        }

        try
        {
            await _appDbContext.AddAsync(recipeList);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return recipeList.Id;
            }
            else
            {
                throw new Exception($"recipe list with id: {recipeList.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"recipe list with id: {recipeList.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<bool> DeleteRecipeListAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var recipeList =
            _appDbContext.RecipeLists.FirstOrDefault(x => x.Id == id);

            if (recipeList == null)
            {
                return false;
            }

            _appDbContext.Remove(recipeList);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete recipeList with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<RecipeList>> GetAllRecipeListsAsync()
    {
        try
        {
            var recipeLists = await _appDbContext.RecipeLists
                .Include(r => r.Rows)
                .ToListAsync();

            foreach (var recipeList in recipeLists)
            {
                recipeList.Rows = recipeList.Rows
                    .OrderBy(row => row.Area ?? string.Empty) // Custom handling for null Area
                    .ToList();
            }

            return recipeLists;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting all RecipeLists. Exception was: {ex.Message}");
        }
    }

    public async Task<RecipeList> GetRecipeListByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.RecipeLists.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting RecipeList with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<RecipeList> GetRecipeListByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RecipeList>> SearchRecipeListByName(string searchString)
    {
        try
        {
            return await _appDbContext.RecipeLists
                .Where(list => list.Name.Contains(searchString))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting recipe lists with search string: {searchString}. Exception was: {ex.Message}");
        }
    }

    public async Task<bool> UpdateRecipeListAsync(RecipeList recipeList)
    {
        if (recipeList == null)
        {
            throw new ArgumentNullException("recipeList was null");
        }

        try
        {

            var recipeListToUpdate = await _appDbContext.FindAsync<RecipeList>(recipeList.Id);

            if (recipeListToUpdate == null)
            {
                throw new Exception($"recipeList with id: {recipeList.Id} was not found");
            }

            recipeListToUpdate.Name = recipeList.Name;
            recipeListToUpdate.Note = recipeList.Note;

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating recipeList with id: {recipeList.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        try
        {
            return await _appDbContext.SaveChangesAsync() >= 0;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
}
