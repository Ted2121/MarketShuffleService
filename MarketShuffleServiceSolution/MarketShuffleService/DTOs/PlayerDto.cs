namespace MarketShuffleService.DTOs;

public class PlayerDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Class { get; set; }
    public int Level { get; set; }
    public bool Exoed { get; set; }
    public string? Description { get; set; }
    public TimeOnly SeenOnline { get; set; }
    public int Ap { get; set; }
    public int Mp { get; set; }
    public string? GuildId { get; set; }
}
