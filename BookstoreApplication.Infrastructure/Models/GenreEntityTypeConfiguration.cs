using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(e => e.GenreId).HasName("PK__Genres__0385055EA1A87A9E");

        builder.Property(e => e.GenreId).HasColumnName("GenreID");
        builder.Property(e => e.GenreName).HasMaxLength(50);
    }
}

