﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assignment_Dataaccess.Models;

#nullable disable

namespace assignment_Dataaccess.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.CategorysEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.OrderItemsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderEntityId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.PriceListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.ProductsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PriceId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("VendorsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.HasIndex("PriceId")
                        .IsUnique();

                    b.HasIndex("VendorsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.VendorsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.CustomerEntity", b =>
                {
                    b.HasOne("assignment_Dataaccess.Models.Enities.AddressEntity", "Address")
                        .WithMany("Residents")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.OrderEntity", b =>
                {
                    b.HasOne("assignment_Dataaccess.Models.Enities.CustomerEntity", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.OrderItemsEntity", b =>
                {
                    b.HasOne("assignment_Dataaccess.Models.Enities.OrderEntity", null)
                        .WithMany("CartItem")
                        .HasForeignKey("OrderEntityId");

                    b.HasOne("assignment_Dataaccess.Models.Enities.ProductsEntity", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.ProductsEntity", b =>
                {
                    b.HasOne("assignment_Dataaccess.Models.Enities.CategorysEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_Dataaccess.Models.Enities.OrderEntity", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_Dataaccess.Models.Enities.PriceListEntity", "Price")
                        .WithOne("Products")
                        .HasForeignKey("assignment_Dataaccess.Models.Enities.ProductsEntity", "PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_Dataaccess.Models.Enities.VendorsEntity", "Vendors")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("VendorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Order");

                    b.Navigation("Price");

                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.AddressEntity", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.CategorysEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.OrderEntity", b =>
                {
                    b.Navigation("CartItem");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.PriceListEntity", b =>
                {
                    b.Navigation("Products")
                        .IsRequired();
                });

            modelBuilder.Entity("assignment_Dataaccess.Models.Enities.VendorsEntity", b =>
                {
                    b.Navigation("CategoryProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
