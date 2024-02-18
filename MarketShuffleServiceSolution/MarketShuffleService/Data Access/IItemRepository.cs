using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<IEnumerable<Item>> GetAllItemsByCategoryAsync(string category);
    Task<Item> GetItemByIdAsync(string id);
    Task<string> CreateItemAsync(Item item);
    Task<bool> UpdateItemAsync(Item item);
    Task<bool> DeleteItemAsync(string id);
    Task<IEnumerable<Item>> SearchItemByName(string searchString);
}
