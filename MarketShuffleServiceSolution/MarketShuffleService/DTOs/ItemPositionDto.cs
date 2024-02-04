namespace MarketShuffleService.DTOs;

public class ItemPositionDto
{
    public string? Id { get; set; }
    public string? Details { get; set; }
    public int StackSize { get; set; }
    public long Date { get; set; }
    public string? ParentItemId { get; set; }
}
