﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopee;

#nullable disable

namespace Shopee.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220428051126_oa-public")]
    partial class oapublic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("char(36)");

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

            modelBuilder.Entity("Shopee.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("OrderByUserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OrderUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<Guid>("ProcessByUserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ShippingId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("pda")
                        .HasColumnType("longtext");

                    b.Property<string>("pdb")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrderByUserId");

                    b.HasIndex("ProcessByUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shopee.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
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
                        .HasColumnType("char(36)");

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
                            Id = new Guid("280459f3-fd08-4927-9f90-4ea7ef057340"),
                            Category = "All"
                        },
                        new
                        {
                            Id = new Guid("925ff2ac-83d9-403e-899e-3837f8582823"),
                            Category = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("da0a4ed7-307d-4fea-97e0-faea2ebf0807"),
                            Category = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("e44e97b6-8244-4279-b792-f71eed4c2b4d"),
                            Category = "TV"
                        },
                        new
                        {
                            Id = new Guid("61ece1b7-d5bf-4d4e-acc8-a7402d6cb6dd"),
                            Category = "Fession"
                        },
                        new
                        {
                            Id = new Guid("1c2e40b0-7200-4548-b7eb-9d7813150942"),
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

            modelBuilder.Entity("Shopee.Models.Shipping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Carrier")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Docket")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("Shopee.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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
                            Id = new Guid("33eca36d-f8a9-44fb-87fe-d466fcb7e073"),
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

            modelBuilder.Entity("Shopee.Models.Order", b =>
                {
                    b.HasOne("Shopee.Models.User", "OrderByUser")
                        .WithMany()
                        .HasForeignKey("OrderByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopee.Models.User", "ProcessByUser")
                        .WithMany()
                        .HasForeignKey("ProcessByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderByUser");

                    b.Navigation("ProcessByUser");
                });

            modelBuilder.Entity("Shopee.Models.OrderItem", b =>
                {
                    b.HasOne("Shopee.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopee.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
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

            modelBuilder.Entity("Shopee.Models.Shipping", b =>
                {
                    b.HasOne("Shopee.Models.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("Shopee.Models.Shipping", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Shopee.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Shipping")
                        .IsRequired();
                });

            modelBuilder.Entity("Shopee.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}