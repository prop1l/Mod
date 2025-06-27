using System;
using System.Collections.Generic;

namespace Mod.Database.Models;

public partial class Enclosure
{
    public int EnclosureId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public decimal? Area { get; set; }

    public string? Location { get; set; }

    public int? Capacity { get; set; }
}
