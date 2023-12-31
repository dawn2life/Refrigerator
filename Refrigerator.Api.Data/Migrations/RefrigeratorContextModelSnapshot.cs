﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Refrigerator.Api.Data.DataAccess;

#nullable disable

namespace Refrigerator.Api.Data.Migrations
{
    [DbContext(typeof(RefrigeratorContext))]
    partial class RefrigeratorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Refrigerator.Api.Domain.Models.FridgeActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeActivityLogs");
                });

            modelBuilder.Entity("Refrigerator.Api.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BaseUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseUnit = "Millilitre",
                            ExpirationDate = new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 2,
                            BaseUnit = "Millilitre",
                            ExpirationDate = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple Juice"
                        },
                        new
                        {
                            Id = 3,
                            BaseUnit = "Gram",
                            ExpirationDate = new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 4,
                            BaseUnit = "Number",
                            ExpirationDate = new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Banana"
                        },
                        new
                        {
                            Id = 5,
                            BaseUnit = "Gram",
                            ExpirationDate = new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 6,
                            BaseUnit = "Gram",
                            ExpirationDate = new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ice Cream"
                        },
                        new
                        {
                            Id = 7,
                            BaseUnit = "Millilitre",
                            ExpirationDate = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mixed Juice"
                        },
                        new
                        {
                            Id = 8,
                            BaseUnit = "Gram",
                            ExpirationDate = new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bread"
                        },
                        new
                        {
                            Id = 9,
                            BaseUnit = "Number",
                            ExpirationDate = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Egg"
                        },
                        new
                        {
                            Id = 10,
                            BaseUnit = "Number",
                            ExpirationDate = new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Donuts"
                        });
                });

            modelBuilder.Entity("Refrigerator.Api.Domain.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Refrigerator.Api.Domain.Models.FridgeActivityLog", b =>
                {
                    b.HasOne("Refrigerator.Api.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Refrigerator.Api.Domain.Models.Stock", b =>
                {
                    b.HasOne("Refrigerator.Api.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
