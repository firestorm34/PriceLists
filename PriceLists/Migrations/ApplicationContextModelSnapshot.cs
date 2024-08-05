﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceLists.Data;

#nullable disable

namespace PriceLists.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PriceLists.Models.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceListId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("PriceLists.Models.PriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("PriceLists.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PriceListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceLists.Models.ProductColumnValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColumnId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColumnValues");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("PriceLists.Models.DateProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<DateTime>("DateValue")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PriceLists.Models.FloatProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<double>("FloatValue")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PriceLists.Models.NumberProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<int>("NumberValue")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("PriceLists.Models.StringProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<string>("StringValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PriceLists.Models.Column", b =>
                {
                    b.HasOne("PriceLists.Models.PriceList", "PriceList")
                        .WithMany()
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("PriceLists.Models.Product", b =>
                {
                    b.HasOne("PriceLists.Models.PriceList", "PriceList")
                        .WithMany()
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("PriceLists.Models.ProductColumnValue", b =>
                {
                    b.HasOne("PriceLists.Models.Column", "Column")
                        .WithMany("ProductColumnValues")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceLists.Models.Product", "Product")
                        .WithMany("ProductColumnValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PriceLists.Models.Column", b =>
                {
                    b.Navigation("ProductColumnValues");
                });

            modelBuilder.Entity("PriceLists.Models.Product", b =>
                {
                    b.Navigation("ProductColumnValues");
                });
#pragma warning restore 612, 618
        }
    }
}
