using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class TitlesByAuthor
{
    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? Titles { get; set; }

    public int? InventoryValue { get; set; }
}
