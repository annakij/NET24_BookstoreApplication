using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF574D7569");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
        builder.Property(e => e.OrderDate).HasColumnType("datetime");
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK__Orders__Customer__619B8048");
    }
}

