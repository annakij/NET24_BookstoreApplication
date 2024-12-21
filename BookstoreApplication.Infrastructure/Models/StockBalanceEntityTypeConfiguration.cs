using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class StockBalanceEntityTypeConfiguration : IEntityTypeConfiguration<StockBalance>
{
    public void Configure(EntityTypeBuilder<StockBalance> builder)
    {
        builder.HasKey(e => new { e.StoreId, e.Isbn }).HasName("PK__StockBal__9FC5238FB8393771");

        builder.ToTable("StockBalance");

        builder.Property(e => e.StoreId).HasColumnName("StoreID");
        builder.Property(e => e.Isbn)
            .HasMaxLength(13)
            .HasColumnName("ISBN");

        builder.HasOne(d => d.IsbnNavigation).WithMany(p => p.StockBalances)
            .HasForeignKey(d => d.Isbn)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__StockBalan__ISBN__37A5467C");

        builder.HasOne(d => d.Store).WithMany(p => p.StockBalances)
            .HasForeignKey(d => d.StoreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__StockBala__Store__36B12243");
    }
}

