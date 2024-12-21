using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookstoreApplication.Infrastructure.Models;

public class AuthorAwardEntityTypeConfiguration : IEntityTypeConfiguration<AuthorAward>
{
    public void Configure(EntityTypeBuilder<AuthorAward> builder)
    {
        builder.HasKey(e => new { e.AuthorId, e.AwardId }).HasName("PK__AuthorAw__8BD26F499F573F2A");

        builder.Property(e => e.AuthorId).HasColumnName("AuthorID");
        builder.Property(e => e.AwardId).HasColumnName("AwardID");

        builder.HasOne(d => d.Author).WithMany(p => p.AuthorAwards)
            .HasForeignKey(d => d.AuthorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__AuthorAwa__Autho__440B1D61");

        builder.HasOne(d => d.Award).WithMany(p => p.AuthorAwards)
            .HasForeignKey(d => d.AwardId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__AuthorAwa__Award__4316F928");
    }
}

