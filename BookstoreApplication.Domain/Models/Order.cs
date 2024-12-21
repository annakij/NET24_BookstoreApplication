﻿using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
