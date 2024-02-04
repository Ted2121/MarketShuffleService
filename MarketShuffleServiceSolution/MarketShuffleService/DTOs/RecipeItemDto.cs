using MarketShuffleModels;

namespace MarketShuffleService.DTOs;

public class RecipeItemDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public string? ParentItemId { get; set; }
}
