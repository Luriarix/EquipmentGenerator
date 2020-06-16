 using EquipmentDatabase;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EquipmentGenerator
{
    public class Processes
    {
        private int i = 0;

        static void Main() { }


        public Item ActiveItem { get; set; }
        public void SelectedItem(object item)
        {
            ActiveItem = (Item)item;
        }

        public List<Item> ReadList()
        {
            var db = new EquipmentContext();
            return db.Items.ToList();
        }
        public void AddItem()
        {
            var db = new EquipmentContext();
            db.Add(new Item { ItemName = $"test {i}" });
            db.SaveChanges();
            i += 1;
        }
        public void AddItem(string name)
        {
            var db = new EquipmentContext();
            db.Add(new Item { ItemName = name });
            db.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i.ItemId == id).First();
            ActiveItem.ItemName = name;
            db.SaveChanges();
        }


        public void RemoveItem()
        {
            var db = new EquipmentContext();
                db.Remove(ActiveItem.ItemId);
                db.SaveChanges();
        }
        public void RemoveAllItems()
        {
            var db = new EquipmentContext();
            foreach (var item in db.Items)
                db.Remove(item);
            db.SaveChanges();
        }
    }
}
