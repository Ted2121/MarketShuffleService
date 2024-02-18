using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class Item
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsFavorite { get; set; }
    public string Category { get; set; }
    public double Buy { get; set; }
    public double Sell { get; set; }
    public IEnumerable<RecipeItem>? Recipe { get; set; }
    public IEnumerable<ItemPosition>? Positions { get; set; }

}
