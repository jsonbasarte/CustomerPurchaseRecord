﻿// <auto-generated />
using System;
using CustomerPurchaseRecord.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerPurchaseRecord.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240128010818_Update_Customer_Entity_Config")]
    partial class Update_Customer_Entity_Config
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("CustomerPurchaseRecord.Entities.DbSet.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerPurchaseRecord.Entities.DbSet.TransactionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("CustomerPurchaseRecord.Entities.DbSet.TransactionDetails", b =>
                {
                    b.HasOne("CustomerPurchaseRecord.Entities.DbSet.Customer", "Customer")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TransactionDetail_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerPurchaseRecord.Entities.DbSet.Customer", b =>
                {
                    b.Navigation("TransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
