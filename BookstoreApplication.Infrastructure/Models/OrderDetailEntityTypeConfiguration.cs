using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(e => e.DetailId).HasName("PK__OrderDet__135C314D4E7A738D");

        builder.Property(e => e.DetailId).HasColumnName("DetailID");
        builder.Property(e => e.Isbn)
            .HasMaxLength(13)
            .HasColumnName("ISBN");
        builder.Property(e => e.OrderId).HasColumnName("OrderID");

        builder.HasOne(d => d.IsbnNavigation).WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.Isbn)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__OrderDetai__ISBN__656C112C");

        builder.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__OrderDeta__Order__6477ECF3");
    }
}

