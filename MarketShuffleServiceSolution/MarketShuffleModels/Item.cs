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
    public string Quality { get; set; }

    public IEnumerable<RecipeItem>? Recipe { get; set; }
    public IEnumerable<ItemPosition>? Positions { get; set; }

}
