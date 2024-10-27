using MarketShuffleModels;
using MarketShuffleService.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class RecipeListRowRepository : IRecipeListRowRepository
{
    private readonly AppDbContext _appDbContext;

    public RecipeListRowRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreateRecipeListRowAsync(RecipeListRow row)
    {
        if (row == null)
        {
            throw new ArgumentNullException(nameof(row));
        }

        if (!String.IsNullOrEmpty(row.Link))
        {
            if (!UrlValidator.ValidateHttps(row.Link))
            {
                throw new ArgumentException($"Invalid URL for row {row.Id}, resource name: {row.ResourceName}, link: {row.Link}");
            }
        }

        try
        {
            // Check if a row with the same ResourceName and RecipeListId already exists
            var existingRow = await _appDbContext.RecipeListRows
                .FirstOrDefaultAsync(r => r.ResourceName.ToLower() == row.ResourceName.ToLower()
                                    && r.RecipeListId == row.RecipeListId);

            if (existingRow != null)
            {
                // Update the quantity of the existing row
                existingRow.Quantity += row.Quantity;

                // Call SaveChangesAsync to save the updated quantity
                var isUpdated = await SaveChangesAsync();

                if (isUpdated)
                {
                    return existingRow.Id;
                }
                else
                {
                    throw new Exception($"row with id: {existingRow.Id} could not be updated with new quantity");
                }
            }

            await _appDbContext.AddAsync(row);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return row.Id;
            }
            else
            {
                throw new Exception($"row with id: {row.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"row with id: {row.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<bool> DeleteRecipeListRowAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var row =
            _appDbContext.RecipeListRows.FirstOrDefault(x => x.Id == id);

            if (row == null)
            {
                return false;
            }

            _appDbContext.Remove<RecipeListRow>(row);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete row with id: {id}. Exception was: {ex}");
        }
    }

    //public async Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsAsync()
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByRecipeListId(string recipeListId)
    {
        try
        {
            return await _appDbContext.RecipeListRows.Where(x => x.RecipeListId == recipeListId).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all recipe list rows. Exception was: {ex.Message}");
        }
    }

    public async Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByResourceName(string resourceName)
    {
        try
        {
            return await _appDbContext.RecipeListRows
                .Where(list => list.ResourceName.Contains(resourceName))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting recipe list rows with search string: {resourceName}. Exception was: {ex.Message}");
        }
    }

    //public async Task<IEnumerable<RecipeListRow>> GetAllRecipeListRowsByResourceNameFromResourceList(string resourceName, string resourceListId)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<RecipeListRow> GetRecipeListRowByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.RecipeListRows.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting recipe list row with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdateRecipeListRowAsync(RecipeListRow row)
    {
        if (row == null)
        {
            throw new ArgumentNullException("row was null");
        }

        try
        {

            var rowToUpdate = await _appDbContext.FindAsync<RecipeListRow>(row.Id);

            if (rowToUpdate == null)
            {
                throw new Exception($"row with id: {row.Id} was not found");
            }

            rowToUpdate.ResourceName = row.ResourceName;
            rowToUpdate.Quantity = row.Quantity;
            rowToUpdate.Note = row.Note ?? "";
            rowToUpdate.Area = row.Area ?? "";
            rowToUpdate.Link = String.IsNullOrEmpty(row.Link) 
                ? ""
                : UrlValidator.ValidateHttps(row.Link) ? row.Link : throw new ArgumentException($"Invalid URL for row {row.Id}, resource name: {row.ResourceName}, link: {row.Link}");

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating row with id: {row.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }
}
