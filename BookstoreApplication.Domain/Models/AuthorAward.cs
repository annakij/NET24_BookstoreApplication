using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class AuthorAward
{
    public int AuthorId { get; set; }

    public int AwardId { get; set; }

    public DateOnly? AwardDate { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Award Award { get; set; } = null!;
}
