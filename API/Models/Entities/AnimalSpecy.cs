using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class AnimalSpecy
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string CageId { get; set; }

    public virtual Cage Cage { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
