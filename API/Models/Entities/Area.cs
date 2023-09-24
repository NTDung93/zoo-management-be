using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Area
{
    public string Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Cage> Cages { get; set; } = new List<Cage>();
}
