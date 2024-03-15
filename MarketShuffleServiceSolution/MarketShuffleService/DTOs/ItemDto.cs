using MarketShuffleModels;

namespace MarketShuffleService.DTOs;

public class ItemDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool IsFavorite { get; set; }
    public double Buy { get; set; }
    public double Sell { get; set; }
    public string? Category { get; set; }
    public int OrderInCategory { get; set; }
    public string? UseFor { get; set; }
    public int RelistCount { get; set; }
    public int SoldCount { get; set; }
    public string? Profession { get; set; }
    public int CraftUntil { get; set; }
    public IEnumerable<RecipeItemDto>? Recipe { get; set; }
    public IEnumerable<ItemPosition>? Positions { get; set; }
}
