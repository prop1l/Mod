using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class ParticipationInTour
{
    public int ParticipationId { get; set; }

    public int? UserId { get; set; }

    public int? TourId { get; set; }

    public string? AttendanceStatus { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public virtual Tour? Tour { get; set; }

    public virtual UserAccount? User { get; set; }
}
