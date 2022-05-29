﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeedyHub.Server.Data;

#nullable disable

namespace SeedyHub.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220512102222_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeedyHub.Shared.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Fruits"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Frozen Goods"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Vegetables"
                        });
                });

            modelBuilder.Entity("SeedyHub.Shared.ItemDetails", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CategoryId = 1,
                            DateOfTransaction = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(977),
                            Description = "The mango fruit is roughly oval in shape, with uneven sides. The fruit is a drupe, with an outer flesh surrounding a stone. The flesh is soft and bright yellow-orange in color. The skin of the fruit is yellow-green to red. Mango trees can grow to a height of 45 m (148 ft) and can live for in excess of 100 years.",
                            Image = "",
                            ItemName = "Mango",
                            Price = 60.0,
                            Quantity = 30,
                            TotalPrice = 1800.0,
                            TotalQuantity = 30
                        },
                        new
                        {
                            ItemId = 2,
                            CategoryId = 2,
                            DateOfTransaction = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(979),
                            Description = "French fries are served hot, either soft or crispy, and are generally eaten as part of lunch or dinner or by themselves as a snack, and they commonly appear on the menus of diners, fast food restaurants, pubs, and bars.",
                            Image = "",
                            ItemName = "Fries",
                            Price = 120.0,
                            Quantity = 50,
                            TotalPrice = 6000.0,
                            TotalQuantity = 50
                        },
                        new
                        {
                            ItemId = 3,
                            CategoryId = 3,
                            DateOfTransaction = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(980),
                            Description = "Filipino eggplants, botanically classified as Solanum melongena, are cultivated in the Philippines and are a member of the Solanaceae, or nightshade family. Similar to the Chinese eggplant and Japanese eggplant, these fruits are known for their sweet flavor, very few seeds, and meaty texture",
                            Image = "",
                            ItemName = "Talong",
                            Price = 20.0,
                            Quantity = 10,
                            TotalPrice = 200.0,
                            TotalQuantity = 20
                        });
                });

            modelBuilder.Entity("SeedyHub.Shared.Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<DateTime?>("Accepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.HasIndex("RoleId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            Accepted = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(962),
                            Birthday = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(960),
                            FirstName = "Jeoganni",
                            Image = "",
                            LastName = "Canda",
                            RoleId = 1,
                            Suffix = "Jr"
                        },
                        new
                        {
                            MemberId = 2,
                            Accepted = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(965),
                            Birthday = new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(964),
                            FirstName = "Juncel",
                            Image = "",
                            LastName = "Diaz",
                            RoleId = 2,
                            Suffix = ""
                        });
                });

            modelBuilder.Entity("SeedyHub.Shared.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Regular"
                        });
                });

            modelBuilder.Entity("SeedyHub.Shared.ItemDetails", b =>
                {
                    b.HasOne("SeedyHub.Shared.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("SeedyHub.Shared.Members", b =>
                {
                    b.HasOne("SeedyHub.Shared.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
