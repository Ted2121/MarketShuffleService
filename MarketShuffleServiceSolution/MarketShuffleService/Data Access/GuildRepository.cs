using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class GuildRepository : IGuildRepository
{
    private readonly AppDbContext _appDbContext;

    public GuildRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreateGuildAsync(Guild guild)
    {
        if (guild == null)
        {
            throw new ArgumentNullException(nameof(guild));
        }

        try
        {
            await _appDbContext.AddAsync(guild);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return guild.Id;
            }
            else
            {
                throw new Exception($"guild with id: {guild.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"guild with id: {guild.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<IEnumerable<Guild>> SearchGuildByName(string searchString)
    {
        try
        {
            return await _appDbContext.Guilds
                .Where(guild => guild.Name.Contains(searchString))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting guilds with search string: {searchString}. Exception was: {ex.Message}");
        }
    }

    public async Task<bool> DeleteGuildAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var guild =
            _appDbContext.Guilds.FirstOrDefault(x => x.Id == id);

            if (guild == null)
            {
                return false;
            }

            _appDbContext.Remove<Guild>(guild);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete guild with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<Guild>> GetAllGuildsAsync()
    {
        try
        {
            return await _appDbContext.Guilds.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all guilds. Exception was: {ex.Message}");
        }
    }

    public async Task<Guild> GetGuildByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.Guilds.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting guild with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdateGuildAsync(Guild guild)
    {
        if (guild == null)
        {
            throw new ArgumentNullException("guild was null");
        }

        try
        {

            var guildToUpdate = await _appDbContext.FindAsync<Guild>(guild.Id);

            if (guildToUpdate == null)
            {
                throw new Exception($"guild with id: {guild.Id} was not found");
            }

            guildToUpdate.Name = guild.Name;
            guildToUpdate.Level = guild.Level;
            guildToUpdate.Description = guild.Description;
            guildToUpdate.Difficult = guild.Difficult;

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating guild with id: {guild.Id}. Exception was: {ex}");
        }
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }
}
