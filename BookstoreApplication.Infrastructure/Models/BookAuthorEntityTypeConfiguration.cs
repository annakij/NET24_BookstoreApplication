using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(ba => new { ba.ISBN, ba.AuthorId }).HasName("PK_BookAuthors");

        builder.ToTable("BookAuthors");

        builder.Property(ba => ba.ISBN)
            .HasMaxLength(13)
            .HasColumnName("ISBN");

        builder.HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.ISBN)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookAuthor_Book");

        builder.HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookAuthor_Author");
    }
}

