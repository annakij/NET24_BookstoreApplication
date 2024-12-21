using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string Isbn { get; set; } = null!;

    public string? Source { get; set; }

    public string? Content { get; set; }

    public DateOnly PublishedDate { get; set; }

    public virtual Book IsbnNavigation { get; set; } = null!;
}
