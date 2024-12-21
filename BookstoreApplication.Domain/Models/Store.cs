using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
