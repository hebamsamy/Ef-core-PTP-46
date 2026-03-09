using EcommerceDB.Configuration;
using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Context
{
    public class EcommerceDBContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=.;Initial Catalog=ECommerceDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());


            modelBuilder.Entity<Category>().HasData(
                new Category { ID= 1, Name = "Food", Description = "Food" },
                new Category { ID = 2, Name = "Cloth", Description = "Cloth" },
                new Category { ID = 3, Name = "Electroics", Description = "Electroics" }
                );

            modelBuilder.Entity<Provider>().HasData(
                new Provider {ID= 1, FullName = "Test", Email = "test@gmail.com", UserName = "test" });


            base.OnModelCreating(modelBuilder);
        }

    }
}
