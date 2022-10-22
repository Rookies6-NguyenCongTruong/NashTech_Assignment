using Microsoft.EntityFrameworkCore;

namespace Assignment2.Models;

public class ProductStoreContext : DbContext
{
    public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
                    .ToTable("Category")
                    .HasKey(c => c.Id);

        modelBuilder.Entity<Category>()
                    .Property(c => c.Id)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int")
                    .IsRequired();

        modelBuilder.Entity<Category>()
                    .Property(c => c.CategoryName)
                    .HasColumnName("CategoryName")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(500);

        modelBuilder.Entity<Product>()
                    .ToTable("Product")
                    .HasKey(c => c.Id);

        modelBuilder.Entity<Product>()
                    .HasOne<Category>(p => p.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
                    .Property(p => p.Id)
                    .HasColumnName("ProductId")
                    .HasColumnType("int")
                    .IsRequired();

        modelBuilder.Entity<Product>()
                    .Property(p => p.ProductName)
                    .HasColumnName("ProductName")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(500);

        modelBuilder.Entity<Product>()
                    .Property(p => p.Manufacture)
                    .HasColumnName("Manufacture")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(500);

        modelBuilder.Entity<Product>()
                    .Property(p => p.CategoryId)
                    .HasColumnName("CategoryId")
                    .HasColumnType("int")
                    .IsRequired();

        modelBuilder.Entity<Category>()
                    .HasData(new Category
                    {
                        Id = 1,
                        CategoryName = "Computers"
                    });

        modelBuilder.Entity<Product>()
                    .HasData(new Product
                    {
                        Id = 1,
                        ProductName = "Laptop Dell",
                        Manufacture = "Viet Nam",
                        CategoryId = 1
                    });
    }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}