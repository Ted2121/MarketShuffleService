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
    public double One { get; set; }
    public double Ten { get; set; }
    public double Hundred { get; set; }
    public long Date { get; set; }
    public string Quality { get; set; }
    public string ParentItemId { get; set; }
    public Item? ParentItem { get; set; }
}
