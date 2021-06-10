using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimToressonLabb3DBWF.Models;

#nullable disable

namespace TimToressonLabb3DBWF.Data
{
    public partial class TimToressonLabb3DBContext : DbContext
    {
        public TimToressonLabb3DBContext()
        {
        }

        public TimToressonLabb3DBContext(DbContextOptions<TimToressonLabb3DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BooksOrder> BooksOrders { get; set; }
        public virtual DbSet<Bookstore> Bookstores { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<VTitlesPerAuthor> VTitlesPerAuthors { get; set; }
        public virtual DbSet<StockBalances> StockBalances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TimToressonLabb3DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnName("Birth Date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("First Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Last Name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn13);

                entity.Property(e => e.Isbn13)
                    .ValueGeneratedNever()
                    .HasColumnName("ISBN13");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PublicationDate).HasColumnName("Publication Date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Authors");
            });

            modelBuilder.Entity<BooksOrder>(entity =>
            {
                entity.HasKey(e => new { e.Isbn13, e.OrderId });

                entity.ToTable("Books_Orders");

                entity.Property(e => e.Isbn13).HasColumnName("ISBN13");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Isbn13Navigation)
                    .WithMany(p => p.BooksOrders)
                    .HasForeignKey(d => d.Isbn13)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Orders_Books");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BooksOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Orders_Orders");
            });

            modelBuilder.Entity<Bookstore>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BookstoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Bookstore Name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Postal Code");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last Name");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnName("Order Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<VTitlesPerAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_TitlesPerAuthors");

                entity.Property(e => e.Age).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InventoryValue)
                    .HasColumnType("money")
                    .HasColumnName("Inventory value");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(101);
            });

            modelBuilder.Entity<StockBalances>(entity =>
            {
                entity.HasKey(e => new { e.BookstoreId, e.Isbn13 });

                entity.ToTable("Stock_Balances");

                entity.Property(e => e.BookstoreId).HasColumnName("BookstoreID");

                entity.Property(e => e.Isbn13).HasColumnName("ISBN13");

                entity.HasOne(d => d.Bookstore)
                    .WithMany(p => p.StockBalances)
                    .HasForeignKey(d => d.BookstoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Balances_Bookstores");

                entity.HasOne(d => d.Isbn13Navigation)
                    .WithMany(p => p.StockBalances)
                    .HasForeignKey(d => d.Isbn13)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Balances_Books");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
