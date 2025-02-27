﻿using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _appDbContext;

    public ItemRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<string> CreateItemAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (string.IsNullOrEmpty(item.Profession)) item.Profession = "Flipping";
        if (string.IsNullOrEmpty(item.UseFor)) item.UseFor = "Flipping";
        if (string.IsNullOrEmpty(item.Category)) item.Category = "None";


        try
        {
            await _appDbContext.AddAsync(item);
            var isSaved = await SaveChangesAsync();

            if (isSaved)
            {
                return item.Id;
            }
            else
            {
                throw new Exception($"item with id: {item.Id} could not be saved");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"item with id: {item.Id} could not be created. Exception was {ex.Message}");
        }
    }

    public async Task<IEnumerable<Item>> SearchItemByName(string searchString)
    {
        try
        {
            return await _appDbContext.Items
                .Where(item => item.Name.Contains(searchString))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed getting items with search string: {searchString}. Exception was: {ex.Message}");
        }
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            var item =
            _appDbContext.Items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return false;
            }

            _appDbContext.Remove<Item>(item);
            var isDeleted = await SaveChangesAsync();

            return isDeleted;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not delete item with id: {id}. Exception was: {ex}");
        }
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        try
        {
            return await _appDbContext.Items.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all items. Exception was: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Item>> GetAllItemsByCategoryAsync(string category)
    {
        try
        {
            return await _appDbContext.Items.Where(x => x.Category == category).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all items for category {category}. Exception was: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Item>> GetAllFavoriteItemsAsync()
    {
        try
        {
            return await _appDbContext.Items.Where(x => x.IsFavorite == true).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all favorite items. Exception was: {ex.Message}");
        }
    }
    public async Task<IEnumerable<Item>> GetAllProfessionsItemsAsync()
    {
        try
        {
            return await _appDbContext.Items.Where(x => x.Profession != "Flipping").ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting all favorite items. Exception was: {ex.Message}");
        }
    }

    public async Task<Item> GetItemByIdAsync(string id)
    {
        if (id == null)
        {
            throw new ArgumentException(nameof(id));
        }

        try
        {
            return await _appDbContext.Items.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting item with id: {id}. Exception was: {ex}");

        }
    }

    public async Task<bool> UpdateItemAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item was null");
        }

        try
        {

            var itemToUpdate = await _appDbContext.FindAsync<Item>(item.Id);

            if (itemToUpdate == null)
            {
                throw new Exception($"item with id: {item.Id} was not found");
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.Category = item.Category;
            itemToUpdate.Sell = item.Sell;
            itemToUpdate.Buy = item.Buy;
            itemToUpdate.IsFavorite = item.IsFavorite;
            itemToUpdate.SoldCount = item.SoldCount;
            itemToUpdate.Profession = item.Profession ?? "Flipping";
            itemToUpdate.RelistCount = item.RelistCount;
            itemToUpdate.UseFor = item.UseFor ?? "Flipping";
            itemToUpdate.CraftUntil = item.CraftUntil;
            itemToUpdate.OrderInCategory = item.OrderInCategory;

            return await SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed updating item with id: {item.Id}. Exception was: {ex}");
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

    public async Task<Item> GetItemByNameAsync(string name)
    {
        if (name == null)
        {
            throw new ArgumentException(nameof(name));
        }

        try
        {
            return await _appDbContext.Items.FirstOrDefaultAsync(u => u.Name == name);
        }
        catch (Exception ex)
        {

            throw new Exception($"Failed getting item with name: {name}. Exception was: {ex}");

        }
    }
}
