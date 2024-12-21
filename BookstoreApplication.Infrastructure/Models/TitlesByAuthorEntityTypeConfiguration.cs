using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class TitlesByAuthorEntityTypeConfiguration : IEntityTypeConfiguration<TitlesByAuthor>
{
    public void Configure(EntityTypeBuilder<TitlesByAuthor> builder)
    {
        builder
                .HasNoKey()
                .ToView("TitlesByAuthor");

        builder.Property(e => e.Name).HasMaxLength(101);
    }
}

