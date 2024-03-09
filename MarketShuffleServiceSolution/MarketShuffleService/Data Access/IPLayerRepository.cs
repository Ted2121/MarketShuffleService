using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task<Player> GetPlayerByIdAsync(string id);
    Task<string> CreatePlayerAsync(Player player);
    Task<bool> UpdatePlayerAsync(Player player);
    Task<bool> DeletePlayerAsync(string id);
    Task<IEnumerable<Player>> SearchPlayerByName(string searchString);
}
