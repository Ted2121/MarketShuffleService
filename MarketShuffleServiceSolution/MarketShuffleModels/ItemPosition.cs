using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShuffleModels;
public class ItemPosition
{
    public string Id { get; set; }
    public string Details { get; set; }
    public int One { get; set; }
    public int Ten { get; set; }
    public int Hundred { get; set; }
    public long Date { get; set; }
    public string Quality { get; set; }
    public string ParentItemId { get; set; }
    public Item? ParentItem { get; set; }
}
