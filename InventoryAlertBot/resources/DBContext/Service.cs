using System;
using System.Collections.Generic;

namespace InventoryAlertBot.resources.DBContext;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Servicename { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
