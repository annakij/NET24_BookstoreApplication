using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class RecentSaleEntityTypeConfiguration : IEntityTypeConfiguration<RecentSale>
{
    public void Configure(EntityTypeBuilder<RecentSale> builder)
    {
        builder
                .HasNoKey()
                .ToView("RecentSales");

        builder.Property(e => e.Author).HasMaxLength(101);
        builder.Property(e => e.Isbn13)
            .HasMaxLength(13)
            .HasColumnName("ISBN13");
        builder.Property(e => e.LatestCustomer).HasMaxLength(51);
        builder.Property(e => e.RecentOrderDate).HasColumnType("datetime");
        builder.Property(e => e.StoreId).HasColumnName("StoreID");
    }
}

