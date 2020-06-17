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
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EquipmentGenerator");
    }

    public partial class Item
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public Types ItemType { get; set; }
        public Rareties CommonItemRarety { get; set; }
        public int ItemDurability { get; set; }
        public List<Properties> ItemProperty { get; set; }
    }
    public partial class UniqueItem
    {
        [Key]
        public int UniqueId { get; set; }
    
        public string UniqueItemName { get; set; }

        public Types UniqueItemType { get; set; }
        public Rareties UniqueItemRarety { get; set; }
        public int UniqueItemDurability { get; set; }
        public List<Properties> UniqueItemProperty { get; set; }
    }

    public partial class Rareties
    {
        [Key]
        public int RaretyId { get; set; }

        public string Rarety { get; set; }
        public int MaxPoints { get; set; }
    }
    public partial class Types
    {
        [Key]
        public int TypeId { get; set; }

        public string Type { get; set; }
    }
    public partial class Properties
    {
        [Key]
        public int PropertyId { get; set; }
        public string Property { get; set; }
    }
}
