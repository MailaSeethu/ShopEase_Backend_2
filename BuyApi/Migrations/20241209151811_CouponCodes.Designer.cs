﻿// <auto-generated />
using System;
using BuyApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuyApi.Migrations
{
    [DbContext(typeof(BuyApiContext))]
    [Migration("20241209151811_CouponCodes")]
    partial class CouponCodes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuyApi.Models.Buy", b =>
                {
                    b.Property<int>("BuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("NoOfItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderPlacedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Orderid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyId");

                    b.ToTable("Buy");
                });

            modelBuilder.Entity("BuyApi.Models.CouponCodes", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("Couponcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApplicable")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CouponId");

                    b.ToTable("CouponCodes");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            Couponcode = "SHOPEASE20",
                            IsApplicable = true,
                            description = "Flat $20 off on minimum purchase of $50 and Free shipping."
                        },
                        new
                        {
                            CouponId = 2,
                            Couponcode = "SUMMERSALE",
                            IsApplicable = false,
                            description = "Flat 25% off on summer collection."
                        },
                        new
                        {
                            CouponId = 3,
                            Couponcode = "FREESHIP",
                            IsApplicable = true,
                            description = "Free shipping on orders over $50"
                        },
                        new
                        {
                            CouponId = 4,
                            Couponcode = "SAVE10",
                            IsApplicable = true,
                            description = "Flat $10 off on your first purchase (min purchase of $50)."
                        },
                        new
                        {
                            CouponId = 5,
                            Couponcode = "BUY2GET50OFF",
                            IsApplicable = true,
                            description = "Buy 2, Get 50% Off on the 3rd One."
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
