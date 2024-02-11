namespace MarketShuffleService.DTOs;

public class ItemPositionDto
{
    public string? Id { get; set; }
    public string? Details { get; set; }
    public string? Quality { get; set; }
    public int One { get; set; }
    public int Ten { get; set; }
    public int Hundred { get; set; }
    public long Date { get; set; }
    public string? ParentItemId { get; set; }
}
