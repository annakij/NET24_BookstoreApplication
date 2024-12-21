using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE57476D06");

        builder.Property(e => e.ReviewId).HasColumnName("ReviewID");
        builder.Property(e => e.Isbn)
            .HasMaxLength(13)
            .HasColumnName("ISBN");
        builder.Property(e => e.Source).HasMaxLength(100);

        builder.HasOne(d => d.IsbnNavigation).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.Isbn)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Reviews__ISBN__571DF1D5");
    }
}

