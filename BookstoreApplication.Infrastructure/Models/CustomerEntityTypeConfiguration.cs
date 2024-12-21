using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId).HasName("PK__Costumer__8E5D69907123B115");

        builder.HasIndex(e => e.Email, "UQ__Costumer__A9D1053468AC5EE0").IsUnique();

        builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(20);
        builder.Property(e => e.LastName).HasMaxLength(30);
        builder.Property(e => e.Phonenumber).HasMaxLength(20);
    }
}

