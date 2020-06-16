using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;


namespace EquipmentDatabase
{
    public class EquipmentContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EquipmentGenerator");
    }

    public partial class Item
    {
        private int _itemId;
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        //public int ItemId
        //{
        //    get { return _itemId; }
        //    set
        //    {
        //        if (ItemId == null)
        //            _itemId = 1;
        //        else
                    
        //    }
        //}
    }
}
