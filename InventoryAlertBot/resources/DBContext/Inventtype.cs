using System;
using System.Collections.Generic;

namespace InventoryAlertBot.resources.DBContext;

public partial class Inventtype
{
    public int Inventtypeid { get; set; }

    public string? Inventname { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
