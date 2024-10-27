using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class RecipeListRow
{
    public string Id { get; set; }
    public int Quantity { get; set; }
    public string ResourceName { get; set; }
    public string? Area { get; set; }
    public string Note { get; set; }
    public RecipeList RecipeList { get; set; }
    public string RecipeListId { get; set; }
}
