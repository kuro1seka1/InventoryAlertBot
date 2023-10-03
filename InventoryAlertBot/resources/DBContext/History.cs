using System;
using System.Collections.Generic;

namespace InventoryAlertBot.resources.DBContext;

public partial class History
{
    public int Historyid { get; set; }

    public string Historydata { get; set; } = null!;
}
