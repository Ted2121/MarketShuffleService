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
    public IEnumerable<RecipeItemDto>? Recipe { get; set; }
    public IEnumerable<ItemPosition>? Positions { get; set; }
}
