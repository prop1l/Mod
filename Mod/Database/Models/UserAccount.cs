using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public int? RoleId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Feeding> FeedingEmployees { get; set; } = new List<Feeding>();

    public virtual ICollection<Feeding> FeedingSuppliers { get; set; } = new List<Feeding>();

    public virtual ICollection<ParticipationInTour> ParticipationInTours { get; set; } = new List<ParticipationInTour>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
