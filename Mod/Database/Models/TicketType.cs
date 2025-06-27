using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class TicketType
{
    public int TicketTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? BasePrice { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
