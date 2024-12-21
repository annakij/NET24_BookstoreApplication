using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class RecentSale
{
    public string Isbn13 { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int StoreId { get; set; }

    public string Author { get; set; } = null!;

    public int? TotalOrders { get; set; }

    public DateTime? RecentOrderDate { get; set; }

    public string LatestCustomer { get; set; } = null!;
}
