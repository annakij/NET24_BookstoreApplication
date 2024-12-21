using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class Award
{
    public int AwardId { get; set; }

    public string AwardTitle { get; set; } = null!;

    public virtual ICollection<AuthorAward> AuthorAwards { get; set; } = new List<AuthorAward>();
}
