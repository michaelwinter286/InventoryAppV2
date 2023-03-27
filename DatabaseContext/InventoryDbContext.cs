using System;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.DatabaseContext
{
    public class InvContext : DbContext
    {
        public InvContext(DbContextOptions<InvContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        private readonly string? _dbPath;

        public InvContext()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var parentDirectory = Directory.GetParent(baseDirectory);

            while (parentDirectory != null && parentDirectory.Name != "InventorySystem")
            {
                parentDirectory = Directory.GetParent(parentDirectory.FullName);
            }

            _dbPath = parentDirectory != null ? Path.Combine(parentDirectory.FullName, "inventory.db") : Path.Combine(baseDirectory, "inventory.db");

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var pepper in defaultInventory)
            {
                modelBuilder.Entity<Inventory>().HasData(pepper.Value);
            }
        }
    }
}
