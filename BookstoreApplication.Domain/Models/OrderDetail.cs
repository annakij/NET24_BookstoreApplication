using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class OrderDetail
{
    public int DetailId { get; set; }

    public int OrderId { get; set; }

    public string Isbn { get; set; } = null!;

    public int Quantity { get; set; }

    public int Price { get; set; }

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
