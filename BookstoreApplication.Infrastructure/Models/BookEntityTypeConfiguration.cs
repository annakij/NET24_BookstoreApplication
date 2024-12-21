using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Isbn13).HasName("PK__Books__3BF79E031951F51C");

        builder.Property(e => e.Isbn13)
            .HasMaxLength(13)
            .HasColumnName("ISBN13");
        builder.Property(e => e.Language).HasMaxLength(20);

        builder.HasMany(d => d.Genres).WithMany(p => p.Isbns)
            .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                r => r.HasOne<Genre>().WithMany()
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookGenre__Genre__3D5E1FD2"),
                l => l.HasOne<Book>().WithMany()
                    .HasForeignKey("Isbn")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookGenres__ISBN__3C69FB99"),
                j =>
                {
                    j.HasKey("Isbn", "GenreId").HasName("PK__BookGenr__B44566BEEC11856C");
                    j.ToTable("BookGenres");
                    j.IndexerProperty<string>("Isbn")
                        .HasMaxLength(13)
                        .HasColumnName("ISBN");
                    j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                });
    }
}

