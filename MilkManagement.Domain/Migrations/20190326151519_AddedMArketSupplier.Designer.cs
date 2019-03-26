﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilkManagement.Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    [DbContext(typeof(MilkManagementDbContext))]
    [Migration("20190326151519_AddedMArketSupplier")]
    partial class AddedMArketSupplier
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1025);

                    b.Property<string>("Contact")
                        .HasMaxLength(20);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CustomerTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsRateAssignedToCustomer");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerRates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CurrentRate");

                    b.Property<int>("CustomerId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<int>("PreviousRate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerRates");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerSupplied", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AfternoonAmount");

                    b.Property<string>("AfternoonSupply");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<float?>("Credit");

                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerTypeId");

                    b.Property<float?>("Debit");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<double>("MorningAmount");

                    b.Property<string>("MorningSupply");

                    b.Property<int>("Rate");

                    b.Property<double?>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("CustomerSupplied");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Expense.DailyExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ExpenseId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("Rate");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("DailyExpense");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Expense.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Market.MarketSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("MarketSupplierAddress")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("MarketSupplierContact")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("MarketSupplierName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("MarketSupplier");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Supplier.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsRateAssignedToSupplier");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("SupplierAddress")
                        .HasMaxLength(20);

                    b.Property<string>("SupplierContact")
                        .HasMaxLength(1025);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Supplier.SupplierRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CurrentRate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<int>("PreviousRate");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierRates");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Supplier.SupplierSupplied", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AfternoonAmount");

                    b.Property<string>("AfternoonPurchase");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("MorningAmount");

                    b.Property<string>("MorningPurchase");

                    b.Property<int>("Rate");

                    b.Property<int>("SupplierId");

                    b.Property<string>("Total");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierSupplied");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.Customer", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Customer.CustomerType", "CustomerType")
                        .WithMany("Customer")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerRates", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Customer.Customer", "Customer")
                        .WithMany("CustomerRates")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerSupplied", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Customer.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MilkManagement.Domain.Entities.Customer.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Expense.DailyExpense", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Expense.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Supplier.SupplierRate", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Supplier.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Supplier.SupplierSupplied", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Supplier.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
