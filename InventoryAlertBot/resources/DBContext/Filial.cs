using System;
using System.Collections.Generic;

namespace InventoryAlertBot.resources.DBContext;

public partial class Filial
{
    public int Filialid { get; set; }

    public string Filialname { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
