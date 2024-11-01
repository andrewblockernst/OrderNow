using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            //PROPIEDAD NAME
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100); 

            //PROPIEDAD PRICE
            entity.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //PROPIEDAD STOCK
            entity.Property(a => a.Stock)
                .IsRequired();
        });
    }
}
