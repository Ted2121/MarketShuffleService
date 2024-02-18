namespace MarketShuffleService.DTOs;

public class ItemPositionDto
{
    public string? Id { get; set; }
    public string? Details { get; set; }
    public string? Quality { get; set; }
    public double One { get; set; }
    public double Ten { get; set; }
    public double Hundred { get; set; }
    public long Date { get; set; }
    public string? ParentItemId { get; set; }
}
