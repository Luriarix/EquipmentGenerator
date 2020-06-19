using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;


namespace EquipmentDatabase
{

    public class EquipmentContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<UniqueItem> UniqueItems { get; set; }
        public DbSet<Rareties> Rarety { get; set; }
        public DbSet<Types> Type { get; set; }
        public DbSet<Properties> Properties { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EquipmentGeneratorV2");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(e =>
            {
                e.HasOne(i => i.ItemProperty )
                    .WithOne(p => p.Items);

                e.HasOne(e => e.CommonItemRarety)
                    .WithOne(r => r.Items);

                e.HasOne(i => i.ItemType)
                    .WithOne(t => t.Items);

            });

            modelBuilder.Entity<Rareties>(e =>
            {
                e.HasKey(e => e.RaretyId);
            });

            modelBuilder.Entity<Types>(e => 
            {
                e.HasKey(e => e.TypeId);
            });

            modelBuilder.Entity<Properties>(e => 
            {
                e.HasKey(e => e.PropertyId);
            });
        }
    }

    public partial class Item
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int TypeForeignId { get; set; }
        public Types ItemType { get; set; }

        public int RaretyForeignId { get; set; }
        public Rareties CommonItemRarety { get; set; }

        public int PropertyForeignId { get; set; }
        public Properties ItemProperty { get; set; }
    }
    public partial class UniqueItem
    {
        [Key]
        public int UniqueId { get; set; }
    
        public string UniqueItemName { get; set; }

        public int TypeId { get; set; }
        public Types UniqueItemType { get; set; }

        public int RaretyId { get; set; }
        public Rareties UniqueItemRarety { get; set; }

        public int PropertyId { get; set; }
        public Properties UniqueItemProperty { get; set; }
    }
    public partial class Rareties
    {
        [Key]
        public int RaretyId { get; set; }

        public string Rarety { get; set; }
        public int MaxPoints { get; set; }

        public int ItemId { get; set; }
        public Item Items { get; set; }
    }
    public partial class Types
    {
        [Key]
        public int TypeId { get; set; }

        public string Type { get; set; }

        public int ItemId { get; set; }
        public Item Items { get; set; }
    }
    public partial class Properties
    {
        [Key]
        public int PropertyId { get; set; }
        public int Durability { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int ItemId { get; set; }
        public Item Items  { get; set; }
    }
}