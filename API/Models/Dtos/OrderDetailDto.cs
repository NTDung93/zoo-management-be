﻿using API.Models.Entities;

namespace API.Models.Dtos
{
    public class OrderDetailDto
    {
        public int? Quantity { get; set; }
        public DateTime? EntryDate { get; set; }
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public OrderDto Order { get; set; }
        public TicketDto Ticket { get; set; }
    }
}
