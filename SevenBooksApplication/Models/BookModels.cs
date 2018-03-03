using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SevenBooksApplication.Models
{

    [Table("Book")]
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(22)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(64)]
        public string Author { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book() {
            Orders = new HashSet<Order>();
        }

        public Book(string title, string isbn, string author)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
        }
        public Book(string title,string isbn,string author,int categoryID,int stock,decimal price)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
            Stock = stock;
            CategoryID = categoryID;
            Price = price;
        }
    }

    [Table("Category")]
    public class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }

    public partial class Order
    {
        public int OrderID { get; set; }

        public int BookID { get; set; }

        [Required]
        public string UserID { get; set; }

        public DateTime DatePurchase { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        [StringLength(15)]
        public string OrderStatus { get; set; }

        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
    }

    public partial class Discount
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal PercentDiscount { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(20, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.PercentDiscount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Discount>()
                .Property(e => e.PercentDiscount)
                .HasPrecision(3, 2);
        }


    }
}