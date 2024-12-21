using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Stores__3214EC278C7BD083");

        builder.Property(e => e.Id).HasColumnName("ID");
        builder.Property(e => e.Name).HasMaxLength(50);

    }
}

