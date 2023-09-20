using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int TicketId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual Order Order { get; set; }

    public virtual Ticket Ticket { get; set; }
}
