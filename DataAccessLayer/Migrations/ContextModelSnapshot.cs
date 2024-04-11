﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("ProductId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductPrice", b =>
                {
                    b.Property<int>("ProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductPriceId"), 1L, 1);

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidityDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductPriceId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductStock", b =>
                {
                    b.Property<int>("ProductStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductStockId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductStockId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductStocks");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UnitType", b =>
                {
                    b.Property<int>("UnitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitTypeId");

                    b.ToTable("UnitType");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Company", null)
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductPrice", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.UnitType", "UnitType")
                        .WithMany("ProductPrices")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductStock", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany("ProductStocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Navigation("ProductPrices");

                    b.Navigation("ProductStocks");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UnitType", b =>
                {
                    b.Navigation("ProductPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
