using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? UserId { get; set; }

    public int? TicketTypeId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public DateOnly? VisitDate { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual TicketType? TicketType { get; set; }

    public virtual UserAccount? User { get; set; }
}
