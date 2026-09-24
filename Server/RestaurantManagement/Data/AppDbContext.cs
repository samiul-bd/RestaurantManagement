using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Interfaces;
using RestaurantManagement.Models;
namespace RestaurantManagement.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _tenantId;

        
        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantService tenantService) : base(options)
        {
            _tenantId = tenantService.GetTenantId();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Category>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<MenuItem>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<Table>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<Reservation>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<Order>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<Payment>().HasQueryFilter(e => e.TenantId == _tenantId);
            modelBuilder.Entity<Coupon>().HasQueryFilter(e => e.TenantId == _tenantId);
        }

        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            foreach (var entry in ChangeTracker.Entries<TenantBase>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.TenantId = _tenantId;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}