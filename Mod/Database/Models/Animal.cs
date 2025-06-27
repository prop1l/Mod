using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string? Name { get; set; }

    public string? Species { get; set; }

    public string? Breed { get; set; }

    public char? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? HealthStatus { get; set; }

    public virtual ICollection<Feeding> Feedings { get; set; } = new List<Feeding>();
}
