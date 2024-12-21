using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreApplication.Domain.Models;

public partial class Book
{
    public string Isbn13 { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Language { get; set; }

    public int Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    [NotMapped]
    public string AuthorNames => string.Join(", ", Authors.Select(a => $"{a.FirstName} {a.LastName}"));

    [NotMapped]
    public int StockCount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

}
