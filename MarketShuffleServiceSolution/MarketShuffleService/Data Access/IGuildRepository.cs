using MarketShuffleModels;

namespace MarketShuffleService.Data_Access;

public interface IGuildRepository
{
    Task<IEnumerable<Guild>> GetAllGuildsAsync();
    Task<Guild> GetGuildByIdAsync(string id);
    Task<string> CreateGuildAsync(Guild guild);
    Task<bool> UpdateGuildAsync(Guild guild);
    Task<bool> DeleteGuildAsync(string id);
    Task<IEnumerable<Guild>> SearchGuildByName(string searchString);
}
