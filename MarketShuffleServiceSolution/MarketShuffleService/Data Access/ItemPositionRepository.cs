using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class ItemPositionRepository : IItemPositionRepository
{
    private readonly AppDbContext _appDbContext;

    public ItemPositionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreateItemPositionAsync(ItemPosition itemPosition)
    {
        if (itemPosition == null)
        {
            throw new ArgumentNullException(nameof(itemPosition));
        }

        try
        {
            await _appDbContext.AddAsync(itemPosition);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return itemPosition.Id;
            }
            else
            {
                throw new Exception($"itemPosition with id: {itemPosition.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"itemPosition with id: {itemPosition.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<bool> DeleteItemPositionAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var itemPosition =
            _appDbContext.ItemPositions.FirstOrDefault(x => x.Id == id);

            if (itemPosition == null)
            {
                return false;
            }

            _appDbContext.Remove<ItemPosition>(itemPosition);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete itemPosition with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<ItemPosition>> GetAllItemPositionsAsync()
    {
        try
        {
            return await _appDbContext.ItemPositions.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all itemPositions. Exception was: {ex.Message}");
        }
    }

    public async Task<IEnumerable<ItemPosition>> GetAllItemPositionsByParentId(string id)
    {
        try
        {
            return await _appDbContext.ItemPositions.Where(x => x.ParentItemId == id).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all itemPositions. Exception was: {ex.Message}");
        }
    }

    public async Task<ItemPosition> GetItemPositionByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.ItemPositions.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting itemPosition with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdateItemPositionAsync(ItemPosition itemPosition)
    {
        if (itemPosition == null)
        {
            throw new ArgumentNullException("itemPosition was null");
        }

        try
        {

            var itemPositionToUpdate = await _appDbContext.FindAsync<ItemPosition>(itemPosition.Id);

            if (itemPositionToUpdate == null)
            {
                throw new Exception($"itemPosition with id: {itemPosition.Id} was not found");
            }

            itemPositionToUpdate.Details = itemPosition.Details;
            itemPositionToUpdate.One = itemPosition.One;
            itemPositionToUpdate.Ten = itemPosition.Ten;
            itemPositionToUpdate.Hundred = itemPosition.Hundred;
            itemPositionToUpdate.Quality = itemPosition.Quality;
            itemPositionToUpdate.Date = itemPosition.Date;

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating itemPosition with id: {itemPosition.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }
}
