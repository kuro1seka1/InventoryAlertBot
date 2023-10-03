using System;
using System.Collections.Generic;

namespace InventoryAlertBot.resources.DBContext;

public partial class Inventory
{
    public int Inventid { get; set; }

    public string Inventname { get; set; } = null!;

    public string Serialnum { get; set; } = null!;

    public DateTime? Datepov { get; set; }

    public DateTime? Datenextpov { get; set; }

    public int Filialid { get; set; }

    public int? Inventtype { get; set; }

    public int? Cabinetid { get; set; }

    public int Statusid { get; set; }

    public int Serviceid { get; set; }

    public DateTime? Servicedate { get; set; }

    public DateTime? Servicenextdate { get; set; }

    public DateTime? Yearofman { get; set; }

    public virtual Cabinet? Cabinet { get; set; }

    public virtual Filial Filial { get; set; } = null!;

    public virtual Inventtype? InventtypeNavigation { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
