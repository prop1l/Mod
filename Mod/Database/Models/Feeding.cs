using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class Feeding
{
    public int FeedingId { get; set; }

    public int? AnimalId { get; set; }

    public int? EmployeeId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? FeedingTime { get; set; }

    public decimal? Quantity { get; set; }

    public string? Notes { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual UserAccount? Employee { get; set; }

    public virtual UserAccount? Supplier { get; set; }
}
