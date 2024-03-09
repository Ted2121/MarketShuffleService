using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class PlayerRepository
{
    private readonly AppDbContext _appDbContext;

    public PlayerRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreatePlayerAsync(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        try
        {
            await _appDbContext.AddAsync(player);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return player.Id;
            }
            else
            {
                throw new Exception($"player with id: {player.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"player with id: {player.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<IEnumerable<Player>> SearchPlayerByName(string searchString)
    {
        try
        {
            return await _appDbContext.Players
                .Where(player => player.Name.Contains(searchString))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting players with search string: {searchString}. Exception was: {ex.Message}");
        }
    }

    public async Task<bool> DeletePlayerAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var player =
            _appDbContext.Players.FirstOrDefault(x => x.Id == id);

            if (player == null)
            {
                return false;
            }

            _appDbContext.Remove<Player>(player);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete player with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        try
        {
            return await _appDbContext.Players.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all players. Exception was: {ex.Message}");
        }
    }

    public async Task<Player> GetPlayerByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.Players.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting player with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdatePlayerAsync(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException("player was null");
        }

        try
        {

            var playerToUpdate = await _appDbContext.FindAsync<Player>(player.Id);

            if (playerToUpdate == null)
            {
                throw new Exception($"player with id: {player.Id} was not found");
            }

            playerToUpdate.Name = player.Name;
            playerToUpdate.Ap = player.Ap;
            playerToUpdate.Mp = player.Mp;
            playerToUpdate.SeenOnline = player.SeenOnline;
            playerToUpdate.Level = player.Level;
            playerToUpdate.Class = player.Class;
            playerToUpdate.Description = player.Description;
            playerToUpdate.Exoed = player.Exoed;
            playerToUpdate.GuildId = player.GuildId;


            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating player with id: {player.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }
}
