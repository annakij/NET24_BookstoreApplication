using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class StockBalance
{
    public int StoreId { get; set; }

    public string Isbn { get; set; } = null!;

    public int Balance { get; set; }

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
