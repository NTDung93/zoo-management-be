using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime? WritingDate { get; set; }

    public string Image { get; set; }

    public string EmpId { get; set; }

    public int SpeciesId { get; set; }

    public string AnimalId { get; set; }

    public virtual Animal Animal { get; set; }

    public virtual Employee Emp { get; set; }

    public virtual AnimalSpecy Species { get; set; }
}
