using System;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Entities;
using static InventorySystem.Entities.DemoInventory;

namespace InventorySystem.DatabaseContext
{
    public class InvContext : DbContext
    {
        
        public DbSet<Item> Items { get; set; }
        //public DbSet<Livestock> Livestocks { get; set; }

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
            foreach (var item in demoInventory)
            {
                modelBuilder.Entity<Item>().HasData(item.Value);
                
            }
            //foreach (var livestock in startingInventory)
            //{
            //    modelBuilder.Entity<Livestock>().HasData(livestock.Value);
            //}
        }
    }
}
