using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using OnlineShoppingWebApp.Models;

namespace OnlineShoppingWebApp
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


            modelBuilder.Entity<User>().Property(u => u.Id).HasDefaultValue(Guid.NewGuid());
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
                Email= "admin@local.com"
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
