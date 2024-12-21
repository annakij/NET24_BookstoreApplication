using System;
using System.Collections.Generic;
using BookstoreApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Infrastructure.Models;

public partial class BookstoreContext : DbContext
{
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorAward> AuthorAwards { get; set; }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<RecentSale> RecentSales { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<StockBalance> StockBalances { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TitlesByAuthor> TitlesByAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(""); // <<==== Add local connectionstring, standard for localhost: "Server=localhost;Database=YourDatabaseName;Trusted_Connection=True;"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<Author>());
        new AwardEntityTypeConfiguration().Configure(modelBuilder.Entity<Award>());
        new AuthorAwardEntityTypeConfiguration().Configure(modelBuilder.Entity<AuthorAward>());
        new BookEntityTypeConfiguration().Configure(modelBuilder.Entity<Book>());
        new ReviewEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
        new BookAuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<BookAuthor>());
        new BookReviewEntityTypeConfiguration().Configure(modelBuilder.Entity<BookReview>());
        new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
        new GenreEntityTypeConfiguration().Configure(modelBuilder.Entity<Genre>());
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderDetailEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderDetail>());
        new RecentSaleEntityTypeConfiguration().Configure(modelBuilder.Entity<RecentSale>());
        new StockBalanceEntityTypeConfiguration().Configure(modelBuilder.Entity<StockBalance>());
        new StoreEntityTypeConfiguration().Configure(modelBuilder.Entity<Store>());
        new TitlesByAuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<TitlesByAuthor>());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

