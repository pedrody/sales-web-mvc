using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Department> Department { get; set; } = default!;
        public DbSet<Models.Seller> Seller { get; set; } = default!;
        public DbSet<Models.SalesRecord> SalesRecord { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.SalesRecord>()
                .HasOne(s => s.Seller)
                .WithMany(sel => sel.Sales)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
