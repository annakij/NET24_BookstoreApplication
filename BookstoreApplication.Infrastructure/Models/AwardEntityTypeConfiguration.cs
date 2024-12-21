using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class AwardEntityTypeConfiguration : IEntityTypeConfiguration<Award>
{
    public void Configure(EntityTypeBuilder<Award> builder)
    {
        builder.HasKey(e => e.AwardId).HasName("PK__Awards__B08935DEC0257930");

        builder.Property(e => e.AwardId).HasColumnName("AwardID");
    }
}

