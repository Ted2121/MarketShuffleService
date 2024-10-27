using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class RecipeList
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public IEnumerable<RecipeListRow>? Rows { get; set; }
}
