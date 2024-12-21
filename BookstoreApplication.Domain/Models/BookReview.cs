using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class BookReview
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateOnly? Published { get; set; }

    public string Author { get; set; } = null!;

    public string? Review { get; set; }

    public string? Source { get; set; }
}
