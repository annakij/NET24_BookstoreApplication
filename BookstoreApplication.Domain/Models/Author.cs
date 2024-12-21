using System;
using System.Collections.Generic;

namespace BookstoreApplication.Domain.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<AuthorAward> AuthorAwards { get; set; } = new List<AuthorAward>();

    public virtual ICollection<Book> Isbns { get; set; } = new List<Book>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

}
