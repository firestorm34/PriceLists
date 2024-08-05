﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceLists.Data;

#nullable disable

namespace PriceLists.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240429145331_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PriceLists.Models.ProductColumnValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColumnId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductColumnValues");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductColumnValue");
                });

            modelBuilder.Entity("PriceLists.Models.DateProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<DateTime>("DateValue")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("DateProductColumnValue");
                });

            modelBuilder.Entity("PriceLists.Models.FloatProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<double>("FloatValue")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("FloatProductColumnValue");
                });

            modelBuilder.Entity("PriceLists.Models.NumberProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<int>("NumberValue")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("NumberProductColumnValue");
                });

            modelBuilder.Entity("PriceLists.Models.StringProductColumnValue", b =>
                {
                    b.HasBaseType("PriceLists.Models.ProductColumnValue");

                    b.Property<string>("StringValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("StringProductColumnValue");
                });
#pragma warning restore 612, 618
        }
    }
}
