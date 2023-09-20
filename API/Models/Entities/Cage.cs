using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Cage
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int? MaxCapacity { get; set; }

    public string AreaId { get; set; }

    public virtual ICollection<AnimalSpecy> AnimalSpecies { get; set; } = new List<AnimalSpecy>();

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual Area Area { get; set; }
}
