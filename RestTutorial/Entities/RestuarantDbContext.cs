using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestTutorial.Entities
{
    public class RestuarantDbContext: DbContext
    {
        public DbSet<Restaurant>  Resturants { get; set; }
        public DbSet<Address> Adresses { get; set; }
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDB;Trusted_Connection=True;";

        public DbSet<Dish> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                 .Property(r => r.Name)
                 .IsRequired()
                 .HasMaxLength(25);


            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

}
