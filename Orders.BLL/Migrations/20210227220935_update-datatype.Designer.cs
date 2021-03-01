﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.BLL;

namespace Orders.BLL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210227220935_update-datatype")]
    partial class updatedatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orders.DAL.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Created = new DateTime(2021, 2, 28, 0, 9, 34, 937, DateTimeKind.Local).AddTicks(2345),
                            IsDeleted = false,
                            TotalPrice = 1000.0,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            Created = new DateTime(2021, 2, 28, 0, 9, 34, 937, DateTimeKind.Local).AddTicks(9762),
                            IsDeleted = false,
                            TotalPrice = 3000.0,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Orders.DAL.Entities.OrderDetials", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetials");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Amount = 2,
                            ItemPrice = 250.0,
                            OrderId = 1,
                            ProductId = 1,
                            ProductName = "IPhone",
                            TotalPrice = 500.0
                        },
                        new
                        {
                            ID = 2,
                            Amount = 2,
                            ItemPrice = 250.0,
                            OrderId = 1,
                            ProductId = 2,
                            ProductName = "MI 10T",
                            TotalPrice = 500.0
                        },
                        new
                        {
                            ID = 3,
                            Amount = 2,
                            ItemPrice = 250.0,
                            OrderId = 2,
                            ProductId = 1,
                            ProductName = "IPhone",
                            TotalPrice = 500.0
                        },
                        new
                        {
                            ID = 4,
                            Amount = 2,
                            ItemPrice = 250.0,
                            OrderId = 2,
                            ProductId = 2,
                            ProductName = "MI 10T",
                            TotalPrice = 500.0
                        });
                });

            modelBuilder.Entity("Orders.DAL.Entities.OrderDetials", b =>
                {
                    b.HasOne("Orders.DAL.Entities.Order", "Order")
                        .WithMany("OrderDetials")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Orders.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderDetials");
                });
#pragma warning restore 612, 618
        }
    }
}
