using MarketShuffleModels;

namespace MarketShuffleService.DTOs;

public class RecipeListDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Note { get; set; }
    public IEnumerable<RecipeListRowDto>? Rows { get; set; }
}
