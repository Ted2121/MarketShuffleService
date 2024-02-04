using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class RecipeItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string ParentItemId { get; set; }
    public Item? ParentItem { get; set; }
}
