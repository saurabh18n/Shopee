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

            modelBuilder.Entity("Shopee.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("e60660a6-b2b2-41d8-bb0b-de656030cf9d"));

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Shopee.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AddedById")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StoreQty")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double");

                    b.Property<string>("specification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("tax")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shopee.Models.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("c1f02b0a-7649-49ca-a91d-73ff1e9177fa"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf0acdb8-10cf-4680-a7ec-3b021a41f38d"),
                            Category = "All"
                        },
                        new
                        {
                            Id = new Guid("a5f6237f-adc0-497f-ad84-3fbd01da81f0"),
                            Category = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("5935173e-43da-4c55-bc58-1ef5e053e0da"),
                            Category = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("f6a91c55-25d7-409d-988d-55d21f393985"),
                            Category = "TV"
                        },
                        new
                        {
                            Id = new Guid("ccf467bb-6696-45d4-875b-ce6659113897"),
                            Category = "Fession"
                        },
                        new
                        {
                            Id = new Guid("0e0a29de-2726-4a84-8d4e-1b82ac509a80"),
                            Category = "Household"
                        });
                });

            modelBuilder.Entity("Shopee.Models.ProductImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_images");
                });

            modelBuilder.Entity("Shopee.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasDefaultValue(new Guid("bcfc7f84-a29c-41d1-8fd0-47a61f6f9500"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

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
                            Id = new Guid("4bdd3b61-70e6-4018-b217-3e0e9dc39fd8"),
                            ContactNumber = "0000000",
                            Email = "admin@local.com",
                            FirstName = "Admin",
                            IsActive = false,
                            IsAdmin = true,
                            LastName = "",
                            Location = "Office",
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Shopee.Models.CartItem", b =>
                {
                    b.HasOne("Shopee.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopee.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopee.Models.Product", b =>
                {
                    b.HasOne("Shopee.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopee.Models.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shopee.Models.ProductCategory", b =>
                {
                    b.HasOne("Shopee.Models.ProductCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Shopee.Models.ProductImages", b =>
                {
                    b.HasOne("Shopee.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shopee.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
