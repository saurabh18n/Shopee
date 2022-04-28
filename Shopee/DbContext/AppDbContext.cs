using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Shopee.Models;

namespace Shopee
{
    public partial class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration["database"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
                // optionsBuilder.UseLoggerFactory(new LoggerFactory());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            #region User
            modelBuilder.Entity<User>().Property(u => u.IsActive).HasDefaultValue(true);
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Password = "admin",
                FirstName = "Admin",
                LastName = "",
                Location = "Office",
                IsAdmin = true,
                ContactNumber = "0000000",
                Email = "admin@local.com"
            });
            #endregion

            #region Product
            modelBuilder.Entity<Product>().HasOne(prod => prod.AddedBy).WithMany().HasForeignKey(prod => prod.AddedById);
            modelBuilder.Entity<Product>().HasOne(prod => prod.Category).WithMany().HasForeignKey(prod => prod.CategoryId);

            #endregion

            #region ProductImeage
            modelBuilder.Entity<ProductImages>().HasOne(img => img.Product).WithMany(prod => prod.Images).HasForeignKey(s => s.ProductId);
            #endregion

            #region ProductCategory
            modelBuilder.Entity<ProductCategory>().HasOne(cat => cat.ParentCategory).WithMany().HasForeignKey(cat => cat.ParentId);
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "All",
                ParentId = null
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "Electronics",
                ParentId = null
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "Mobile",
                ParentId = null
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "TV",
                ParentId = null
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "Fession",
                ParentId = null
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Category = "Household",
                ParentId = null
            });
            #endregion

            #region CartItem
            modelBuilder.Entity<CartItem>().HasOne(cart => cart.User).WithMany().HasForeignKey(cart => cart.UserId);
            modelBuilder.Entity<CartItem>().HasOne(cart => cart.Product).WithMany().HasForeignKey(cart => cart.ProductId);
            #endregion

            #region Order
            modelBuilder.Entity<Order>().HasOne(O => O.Shipping).WithOne(s => s.Order).HasForeignKey<Shipping>(s => s.OrderId);
            #endregion

            #region Order Item
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.Items).HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>().HasOne(Oi => Oi.Product).WithMany().HasForeignKey(oi => oi.ProductId);
            #endregion


            #region Shipping
            // modelBuilder.Entity<Shipping>().HasOne(s => s.Order).WithOne(o => o.Shipping).HasForeignKey<Order>(s => s.ShippingId);
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductImages> ProductImages { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> Categories { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
