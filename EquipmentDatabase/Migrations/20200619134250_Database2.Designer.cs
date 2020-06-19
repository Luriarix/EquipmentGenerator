﻿// <auto-generated />
using System;
using EquipmentDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquipmentDatabase.Migrations
{
    [DbContext(typeof(EquipmentContext))]
    [Migration("20200619134250_Database2")]
    partial class Database2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EquipmentDatabase.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyForeignId")
                        .HasColumnType("int");

                    b.Property<int>("RaretyForeignId")
                        .HasColumnType("int");

                    b.Property<int>("TypeForeignId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EquipmentDatabase.Properties", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defence")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .HasColumnType("int");

                    b.Property<int>("Inteligence")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("EquipmentDatabase.Rareties", b =>
                {
                    b.Property<int>("RaretyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("int");

                    b.Property<string>("Rarety")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RaretyId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Rarety");
                });

            modelBuilder.Entity("EquipmentDatabase.Types", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Type");
                });

            modelBuilder.Entity("EquipmentDatabase.UniqueItem", b =>
                {
                    b.Property<int>("UniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("RaretyId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UniqueItemPropertyPropertyId")
                        .HasColumnType("int");

                    b.Property<int?>("UniqueItemRaretyRaretyId")
                        .HasColumnType("int");

                    b.Property<int?>("UniqueItemTypeTypeId")
                        .HasColumnType("int");

                    b.HasKey("UniqueId");

                    b.HasIndex("UniqueItemPropertyPropertyId");

                    b.HasIndex("UniqueItemRaretyRaretyId");

                    b.HasIndex("UniqueItemTypeTypeId");

                    b.ToTable("UniqueItems");
                });

            modelBuilder.Entity("EquipmentDatabase.Properties", b =>
                {
                    b.HasOne("EquipmentDatabase.Item", "Items")
                        .WithOne("ItemProperty")
                        .HasForeignKey("EquipmentDatabase.Properties", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentDatabase.Rareties", b =>
                {
                    b.HasOne("EquipmentDatabase.Item", "Items")
                        .WithOne("CommonItemRarety")
                        .HasForeignKey("EquipmentDatabase.Rareties", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentDatabase.Types", b =>
                {
                    b.HasOne("EquipmentDatabase.Item", "Items")
                        .WithOne("ItemType")
                        .HasForeignKey("EquipmentDatabase.Types", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentDatabase.UniqueItem", b =>
                {
                    b.HasOne("EquipmentDatabase.Properties", "UniqueItemProperty")
                        .WithMany()
                        .HasForeignKey("UniqueItemPropertyPropertyId");

                    b.HasOne("EquipmentDatabase.Rareties", "UniqueItemRarety")
                        .WithMany()
                        .HasForeignKey("UniqueItemRaretyRaretyId");

                    b.HasOne("EquipmentDatabase.Types", "UniqueItemType")
                        .WithMany()
                        .HasForeignKey("UniqueItemTypeTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
