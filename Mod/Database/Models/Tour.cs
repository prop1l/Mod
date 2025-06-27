using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class Tour
{
    public int TourId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartTime { get; set; }

    public TimeOnly? Duration { get; set; }

    public int? MaxParticipants { get; set; }

    public int? GuideId { get; set; }

    public virtual UserAccount? Guide { get; set; }

    public virtual ICollection<ParticipationInTour> ParticipationInTours { get; set; } = new List<ParticipationInTour>();
}
