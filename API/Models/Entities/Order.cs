using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public int? PhoneNumber { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual TransactionHistory TransactionHistory { get; set; }
}
