﻿// <auto-generated />
using System;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(DogusEshopDbContext))]
    partial class DogusEshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "P1 Açıklaması",
                            ImageUrl = "https://placehold.co/400",
                            IsActive = true,
                            Name = "P1",
                            Price = 1m
                        },
                        new
                        {
                            Id = 2,
                            Description = "P2 Açıklaması",
                            ImageUrl = "https://placehold.co/400",
                            IsActive = true,
                            Name = "P2",
                            Price = 1m
                        },
                        new
                        {
                            Id = 3,
                            Description = "P3 Açıklaması",
                            ImageUrl = "https://placehold.co/400",
                            IsActive = true,
                            Name = "P3",
                            Price = 1m
                        },
                        new
                        {
                            Id = 4,
                            Description = "P4 Açıklaması",
                            ImageUrl = "https://placehold.co/400",
                            IsActive = true,
                            Name = "P4",
                            Price = 1m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
