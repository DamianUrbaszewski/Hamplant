using Hamplant.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Hamplant.DAL
{
    public class HamplantContext: DbContext
    {
        public HamplantContext(DbContextOptions<HamplantContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMemeber> TeamMembers { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyTypeDefinition> SupplyTypeDefinitions { get; set; }
        public DbSet<SupplyCategory> SupplyCategories { get; set; }
        public DbSet<SupplyType> SupplyTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMemeber>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMemebers)
                .HasForeignKey(tm => tm.TeamId);

            modelBuilder.Entity<TeamMemeber>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TeamMemebers)
                .HasForeignKey(tm => tm.UserId);

            modelBuilder.Entity<Bucket>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Buckets)
                .HasForeignKey(tm => tm.TeamId);

            modelBuilder.Entity<SupplyTypeDefinition>()
                .HasOne(std => std.SupplyType)
                .WithMany()
                .HasForeignKey(std => std.SupplyTypeId);

            modelBuilder.Entity<SupplyTypeDefinition>()
                .HasOne(std => std.SupplyCategory)
                .WithMany()
                .HasForeignKey(std => std.SupplyCategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supply)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplyId);

            modelBuilder.Entity<Supply>()
                .HasOne(s => s.Bucket)
                .WithMany(b => b.Supplies)
                .HasForeignKey(s => s.BucketId);

            modelBuilder.Entity<Supply>()
                .HasOne(s => s.SupplyType)
                .WithMany()
                .HasForeignKey(s => s.SupplyTypeId);

            modelBuilder.Entity<Supply>()
                .HasOne(s => s.NumberOfSupplies)
                .WithOne()
                .HasForeignKey<Supply>(s => s.NumberOfSuppliesId);

            modelBuilder.Entity<Product>()
                .HasOne(s => s.NumberOfProduct)
                .WithOne()
                .HasForeignKey<Product>(s => s.NumberOfProductId);
        }
    }
}
