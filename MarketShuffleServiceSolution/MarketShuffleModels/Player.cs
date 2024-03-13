using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class Player
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public bool Exoed { get; set; }
    public string Description { get; set; }
    public TimeOnly SeenOnline { get; set; }
    public int Ap { get; set; }
    public int Mp { get; set; }
    public string GuildId { get; set; }
    public Guild Guild { get; set; }
}
