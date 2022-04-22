﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopee;

#nullable disable

namespace Shopee.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Shopee.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("7d0a0c94-ac38-44bf-84b2-bac47259863b"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6495bef3-04bf-4bc7-b407-958681347e6e"),
                            ContactNumber = "0000000",
                            Email = "admin@local.com",
                            FirstName = "Admin",
                            IsAdmin = true,
                            LastName = "",
                            Location = "Office",
                            Password = "admin",
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
