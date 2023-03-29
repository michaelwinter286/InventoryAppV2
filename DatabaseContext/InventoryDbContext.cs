using System;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Entities;
using static InventorySystem.Entities.DemoItem;
using static InventorySystem.Entities.DemoLivestock;


namespace InventorySystem.DatabaseContext
{
    public class InventoryContext : DbContext
    {
        
        public DbSet<Item> Items { get; set; }
        public DbSet<Livestock> Livestocks { get; set; }

        public string DbPath { get; }

        public InventoryContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "iventory.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in demoItem)
            {
                modelBuilder.Entity<Item>().HasData(item.Value);
                
            }
            foreach (var livestock in demoLivestock)
            {
                modelBuilder.Entity<Livestock>().HasData(livestock.Value);
            }
        }
    }
}
