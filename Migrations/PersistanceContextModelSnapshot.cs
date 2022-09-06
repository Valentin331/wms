﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wms.Persistance;

#nullable disable

namespace wms.Migrations
{
    [DbContext(typeof(PersistanceContext))]
    partial class PersistanceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeliveryPackage", b =>
                {
                    b.Property<int>("DeliveriesId")
                        .HasColumnType("integer");

                    b.Property<int>("PackagesId")
                        .HasColumnType("integer");

                    b.HasKey("DeliveriesId", "PackagesId");

                    b.HasIndex("PackagesId");

                    b.ToTable("DeliveryPackage");
                });

            modelBuilder.Entity("TruckUser", b =>
                {
                    b.Property<int>("DriversId")
                        .HasColumnType("integer");

                    b.Property<int>("TrucksId")
                        .HasColumnType("integer");

                    b.HasKey("DriversId", "TrucksId");

                    b.HasIndex("TrucksId");

                    b.ToTable("TruckUser");
                });

            modelBuilder.Entity("wms.Entites.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DrivenById")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TruckId")
                        .HasColumnType("integer");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<int>("WarehouseFromId")
                        .HasColumnType("integer");

                    b.Property<int>("WarehouseToId")
                        .HasColumnType("integer");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DrivenById");

                    b.HasIndex("TruckId");

                    b.HasIndex("WarehouseFromId");

                    b.HasIndex("WarehouseToId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("wms.Entites.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<int?>("StoredAtWarehouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StoredAtWarehouseId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("wms.Entites.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AreaCapacity")
                        .HasColumnType("real");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("WeightCapacity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("wms.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdminToWarehouseId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdminToWarehouseId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "brian.brown@wms.com",
                            FirstName = "Brian",
                            LastName = "Brown",
                            Password = "1234",
                            UserType = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "andrew.white@wms.com",
                            FirstName = "Andrew",
                            LastName = "White",
                            Password = "5678",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("wms.Entites.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DeliveryPackage", b =>
                {
                    b.HasOne("wms.Entites.Delivery", null)
                        .WithMany()
                        .HasForeignKey("DeliveriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wms.Entites.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TruckUser", b =>
                {
                    b.HasOne("wms.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wms.Entites.Truck", null)
                        .WithMany()
                        .HasForeignKey("TrucksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wms.Entites.Delivery", b =>
                {
                    b.HasOne("wms.Entites.User", "DrivenBy")
                        .WithMany()
                        .HasForeignKey("DrivenById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wms.Entites.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wms.Entites.Warehouse", "WarehouseFrom")
                        .WithMany()
                        .HasForeignKey("WarehouseFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wms.Entites.Warehouse", "WarehouseTo")
                        .WithMany()
                        .HasForeignKey("WarehouseToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrivenBy");

                    b.Navigation("Truck");

                    b.Navigation("WarehouseFrom");

                    b.Navigation("WarehouseTo");
                });

            modelBuilder.Entity("wms.Entites.Package", b =>
                {
                    b.HasOne("wms.Entites.Warehouse", "StoredAtWarehouse")
                        .WithMany("Packages")
                        .HasForeignKey("StoredAtWarehouseId");

                    b.Navigation("StoredAtWarehouse");
                });

            modelBuilder.Entity("wms.Entites.User", b =>
                {
                    b.HasOne("wms.Entites.Warehouse", "AdminToWarehouse")
                        .WithMany("WarehouseAdministrators")
                        .HasForeignKey("AdminToWarehouseId");

                    b.Navigation("AdminToWarehouse");
                });

            modelBuilder.Entity("wms.Entites.Warehouse", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("WarehouseAdministrators");
                });
#pragma warning restore 612, 618
        }
    }
}
