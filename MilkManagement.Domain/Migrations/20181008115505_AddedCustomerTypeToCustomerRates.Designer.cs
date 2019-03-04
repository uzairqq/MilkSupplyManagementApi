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
    [Migration("20181008115505_AddedCustomerTypeToCustomerRates")]
    partial class AddedCustomerTypeToCustomerRates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
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

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int>("CurrentRate");

                    b.Property<int>("CustomerRatesId");

                    b.Property<int>("CustomerTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("LastUpdatedById");

                    b.Property<DateTime?>("LastUpdatedOn");

                    b.Property<int>("PreviousRate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRatesId");

                    b.HasIndex("CustomerTypeId");

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

                    b.Property<int>("CustomerRatesId");

                    b.Property<float?>("Debit");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("LastUpdatedById");

                    b.Property<DateTime?>("LastUpdatedOn");

                    b.Property<double>("MorningAmount");

                    b.Property<string>("MorningSupply");

                    b.Property<float?>("Rate");

                    b.Property<double?>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRatesId");

                    b.ToTable("CustomerSupplied");
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
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
                        .HasForeignKey("CustomerRatesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MilkManagement.Domain.Entities.Customer.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MilkManagement.Domain.Entities.Customer.CustomerSupplied", b =>
                {
                    b.HasOne("MilkManagement.Domain.Entities.Customer.Customer", "FkCustomer")
                        .WithMany("CustomerSupplied")
                        .HasForeignKey("CustomerRatesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
