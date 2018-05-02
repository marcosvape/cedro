using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroAPI.Models
{
    public class CedroContext : DbContext
    {
        public CedroContext()
        { }

        public CedroContext(DbContextOptions<CedroContext> options)
            : base(options)
        { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        private void ConfigurateRestaurant(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(etd =>
            {
                etd.ToTable("RESTAURANT");
                etd.HasKey(p => p.Id).HasName("id");
                etd.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            });
        }

        private void ConfigurateMenu(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(etd =>
            {
                etd.ToTable("MENU");
                etd.HasKey(c => c.Id).HasName("id");
                etd.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
                etd.Property(c => c.RestaurantId).HasColumnName("restaurantId").IsRequired();
                etd.Property(c => c.Price).HasColumnName("price").IsRequired();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("Cedro");

            ConfigurateRestaurant(modelBuilder);
            ConfigurateMenu(modelBuilder);
        }

    }
}
