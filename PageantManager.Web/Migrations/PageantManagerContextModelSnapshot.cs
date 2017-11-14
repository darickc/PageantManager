﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PageantManager.Business.Entities;
using System;

namespace PageantManager.Web.Migrations
{
    [DbContext(typeof(PageantManagerContext))]
    partial class PageantManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("PageantManager.Business.Entities.Costume", b =>
                {
                    b.Property<int>("CostumeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int>("PageantId");

                    b.HasKey("CostumeId");

                    b.ToTable("Costumes");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.Garment", b =>
                {
                    b.Property<int>("GarmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<decimal?>("ChestMax");

                    b.Property<decimal?>("ChestMin");

                    b.Property<int>("GarmentTypeId");

                    b.Property<decimal?>("HeadMax");

                    b.Property<decimal?>("HeadMin");

                    b.Property<decimal?>("InseamMax");

                    b.Property<decimal?>("InseamMin");

                    b.Property<DateTime?>("RetiredDate");

                    b.Property<decimal?>("WaistMax");

                    b.Property<decimal?>("WaistMin");

                    b.HasKey("GarmentId");

                    b.HasIndex("GarmentTypeId");

                    b.ToTable("Garments");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.GarmentType", b =>
                {
                    b.Property<int>("GarmentTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CostumeId");

                    b.Property<string>("Name")
                        .HasMaxLength(75);

                    b.Property<int>("PageantId");

                    b.HasKey("GarmentTypeId");

                    b.HasIndex("CostumeId");

                    b.ToTable("GarmentTypes");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.Pageant", b =>
                {
                    b.Property<int>("PageantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(75);

                    b.HasKey("PageantId");

                    b.ToTable("Pageants");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.Performance", b =>
                {
                    b.Property<int>("PerformanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApplicationEndDate");

                    b.Property<DateTime>("ApplicationStartDate");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("PageantId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("PerformanceId");

                    b.HasIndex("PageantId");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.Garment", b =>
                {
                    b.HasOne("PageantManager.Business.Entities.GarmentType", "GarmentType")
                        .WithMany()
                        .HasForeignKey("GarmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PageantManager.Business.Entities.GarmentType", b =>
                {
                    b.HasOne("PageantManager.Business.Entities.Costume")
                        .WithMany("GarmentTypes")
                        .HasForeignKey("CostumeId");
                });

            modelBuilder.Entity("PageantManager.Business.Entities.Performance", b =>
                {
                    b.HasOne("PageantManager.Business.Entities.Pageant", "Pageant")
                        .WithMany()
                        .HasForeignKey("PageantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
