using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public string ProductCode { get; set; }

    public decimal? Price { get; set; }

    public DateTime? DateCreate { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
}
