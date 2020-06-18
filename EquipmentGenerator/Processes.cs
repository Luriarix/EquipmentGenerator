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

        public Types ActiveType { get; set; }
        public void SelectedType(object type)
        {
            ActiveType = (Types)type;
        }

        public Rareties ActiveRarety { get; set; }
        public void SelectedRarety(object rarety)
        {
            ActiveRarety = (Rareties)rarety;
        }





        public List<Item> ReadItemList()
        {
            var db = new EquipmentContext();
            return db.Items.ToList();
        }
        public List<UniqueItem> ReadUniqueItemList()
        {
            var db = new EquipmentContext();
            return db.UniqueItems.ToList();
        }
        public List<Rareties> ReadRaretiesList()
        {
            var db = new EquipmentContext();
            return db.Rarety.ToList();
        }
        public List<Types> ReadTypesList()
        {
            var db = new EquipmentContext();
            return db.Type.ToList();
        }
        public List<Properties> ReadPropertiesList()
        {
            var db = new EquipmentContext();
            return db.Properties.ToList();
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
            db.Add(new Item { 
                ItemName = name });
            db.SaveChanges();
        }

        public void AddUniques(string name)
        {
            var db = new EquipmentContext();
            db.Add(new UniqueItem
            {
                UniqueItemName = name          
            });
            db.SaveChanges();
        }

        public void AddRareties()
        {
            var db = new EquipmentContext();
            db.Add(new Rareties { Rarety = $"test {i}", MaxPoints = i});
            db.SaveChanges();
            i += 1;
        }
        public void AddRareties(string name)
        {
            var db = new EquipmentContext();
            db.Add(new Rareties
            {
                Rarety = name,
               // MaxPoints = 
            });
            db.SaveChanges();
        }

        public void AddType()
        {
            var db = new EquipmentContext();
            db.Add(new Types { Type = $"test {i}" });
            db.SaveChanges();
            i += 1;
        }
        public void AddType(string name)
        {
            var db = new EquipmentContext();
            db.Add(new Types
            {
                Type = name
            });
            db.SaveChanges();
        }


        public void AddProperty()
        {
            var db = new EquipmentContext();
            db.Add(new Properties
            {
            });
            db.SaveChanges();
        }


        public void UpdateItem(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i.ItemId == id).First();
            ActiveItem.ItemName = name;
            if (ActiveType != null)
                ActiveItem.ItemType = ActiveType;
            if (ActiveRarety != null)
                ActiveItem.CommonItemRarety = ActiveRarety;
            db.SaveChanges();
        }
        public void UpdateType(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveType = db.Type.Where(t => t.TypeId == id).First();
            ActiveType.Type = name;
            db.SaveChanges();
        }
        public void UpdateRarety(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveRarety = db.Rarety.Where(r => r.RaretyId == id).First();
            ActiveRarety.Rarety = name;
            db.SaveChanges();
        }
        public void UpdateProperties(int id)
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i.ItemId == id).First();
            ActiveItem.ItemProperty.Durability = i;
            ActiveItem.ItemProperty.Attack = i;
            ActiveItem.ItemProperty.Defence = i;
            ActiveItem.ItemProperty.Strength = i;
            ActiveItem.ItemProperty.Dexterity = i;
            ActiveItem.ItemProperty.Inteligence = i;
            db.SaveChanges();
        }





        public void RemoveItem()
        {
            var db = new EquipmentContext();
                db.Remove(ActiveItem);
                db.SaveChanges();
        }
        public void RemoveType()
        {
            var db = new EquipmentContext();
            db.Remove(ActiveType);
            db.SaveChanges();
        }
        public void RemoveRarety()
        {
            var db = new EquipmentContext();
            db.Remove(ActiveRarety);
            db.SaveChanges();
        }

    }
}