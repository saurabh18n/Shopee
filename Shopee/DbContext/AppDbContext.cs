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
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            #region User

            modelBuilder.Entity<User>().Property(u => u.Id).HasDefaultValue(Guid.NewGuid());
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

            #endregion

            #region ProductImeage
            modelBuilder.Entity<ProductImages>().HasOne(img => img.Product).WithMany(prod => prod.Images).HasForeignKey(s => s.ProductId);
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
