using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class ImportHistory
{
    public int No { get; set; }

    public DateTime? ImportDate { get; set; }

    public int? Quantity { get; set; }

    public int FoodId { get; set; }

    public virtual Food Food { get; set; }
}
