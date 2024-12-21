using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class BookReviewEntityTypeConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> builder)
    {
        builder
                .HasNoKey()
                .ToView("BookReviews");

        builder.Property(e => e.Author).HasMaxLength(101);
        builder.Property(e => e.Isbn)
            .HasMaxLength(13)
            .HasColumnName("ISBN");
        builder.Property(e => e.Source).HasMaxLength(100);
    }
}

