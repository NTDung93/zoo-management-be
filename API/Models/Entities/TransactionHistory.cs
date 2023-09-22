﻿using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class TransactionHistory
{
    public int Id { get; set; }

    public string PaymentMethod { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public byte? PaymentStatus { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; }
}