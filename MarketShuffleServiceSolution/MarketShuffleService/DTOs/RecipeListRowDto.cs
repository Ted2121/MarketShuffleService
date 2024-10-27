namespace MarketShuffleService.DTOs;

public class RecipeListRowDto
{
    public string? Id { get; set; }
    public int Quantity { get; set; }
    public string ResourceName { get; set; }
    public string? Area { get; set; }
    public string? Note { get; set; }
    public string? Link { get; set; }
    public string? RecipeListId { get; set; }
}
