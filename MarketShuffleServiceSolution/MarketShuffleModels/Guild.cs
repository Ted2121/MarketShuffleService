using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class Guild
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public bool Difficult { get; set; }
    public IEnumerable<Player> Players { get; set; }
}
