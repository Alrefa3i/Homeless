using Microsoft.EntityFrameworkCore;

namespace HomeLess.Models
{
    public class AppDBContaxt : DbContext
    {
        public AppDBContaxt(DbContextOptions<AppDBContaxt> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships for Categories and Products
            modelBuilder.Entity<product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Configure relationships for Products and Comments
            modelBuilder.Entity<Comment>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Comment>()
                .HasOne(r => r.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(so => so.User)
                .WithMany(s => s.Orders)
                .HasForeignKey(so => so.UserId);

            modelBuilder.Entity<Testimonial>()
               .HasOne(so => so.User)
               .WithMany(s => s.Testimonials)
               .HasForeignKey(so => so.UserId);

            modelBuilder.Entity<Order_Product>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Order_Product>()
                .HasOne(so => so.Order)
                .WithMany(s => s.Order_Product)
                .HasForeignKey(so => so.OrderId);

            modelBuilder.Entity<Order_Product>()
               .HasOne(so => so.Product)
               .WithMany(s => s.Order_Product)
               .HasForeignKey(so => so.ProductId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
