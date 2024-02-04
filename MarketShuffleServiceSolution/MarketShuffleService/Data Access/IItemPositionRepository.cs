using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IItemPositionRepository
{
    Task<IEnumerable<ItemPosition>> GetAllItemPositionsAsync();
    Task<ItemPosition> GetItemPositionByIdAsync(string id);
    Task<string> CreateItemPositionAsync(ItemPosition itemPosition);
    Task<bool> UpdateItemPositionAsync(ItemPosition itemPosition);
    Task<bool> DeleteItemPositionAsync(string id);
}
