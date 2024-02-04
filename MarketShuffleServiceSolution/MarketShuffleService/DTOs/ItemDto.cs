using MarketShuffleModels;

namespace MarketShuffleService.DTOs;

public class ItemDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool IsFavorite { get; set; }
    public string? Quality { get; set; }
    public IEnumerable<RecipeItem>? Recipe { get; set; }
    public IEnumerable<ItemPosition>? Positions { get; set; }
}
