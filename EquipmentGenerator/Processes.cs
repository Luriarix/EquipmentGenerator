 using EquipmentDatabase;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EquipmentGenerator
{
    public class Processes
    {
        private int _i = 0;

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
        public void SelectedType(int id)
        {
            var db = new EquipmentContext();
            foreach (var t in db.Type)
            {
                if (t.TypeId == id)
                    ActiveType = t;
            }
        }


        public Rareties ActiveRarety { get; set; }
        public void SelectedRarety(object rarety)
        {
            ActiveRarety = (Rareties)rarety;
        }
        public void SelectedRarety(int id)
        {
            var db = new EquipmentContext();
            foreach (var r in db.Rarety)
            {
                if (r.RaretyId == id)
                    ActiveRarety = r;
            }
        }


        public Properties ActiveProperties { get; set; }
        public void SelectedProperties (int id)
        {
            var db = new EquipmentContext();
            foreach (var p in db.Properties)
            {
                if (p.PropertyId == id)
                    ActiveProperties = p;
            }
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
            db.Add(new Item { ItemName = $"test {_i}" });
            db.SaveChanges();
            _i += 1;
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
            db.Add(new Rareties { Rarety = $"test {_i}", MaxPoints = _i});
            db.SaveChanges();
            _i += 1;
        }
        public void AddRareties(string name, int max)
        {
            var db = new EquipmentContext();
            db.Add(new Rareties
            {
                Rarety = name,
                MaxPoints = max
            });
            db.SaveChanges();
        }

        public void AddType()
        {
            var db = new EquipmentContext();
            db.Add(new Types { Type = $"test {_i}" });
            db.SaveChanges();
            _i += 1;
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

        public void AddProperties(int id, int dur, int att, int def, int str, int dex, int inte)
        {
            var db = new EquipmentContext();
            db.Add(new Properties
            {
                Durability = dur,
                Attack = att,
                Defence = def,
                Strength = str,
                Dexterity = dex,
                Inteligence = inte,
                ItemId = id
            });
            db.SaveChanges();
        }


        public void UpdateItem(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i.ItemId == id).First();
            ActiveItem.ItemName = name;
            if (ActiveType != null)
            {
                ActiveItem.ItemType = ActiveType;
                ActiveItem.TypeId = ActiveType.TypeId;
            }
            if (ActiveRarety != null)
            {
                ActiveItem.CommonItemRarety = ActiveRarety;
                ActiveItem.RaretyId = ActiveRarety.RaretyId; 
            }
            db.SaveChanges();
        }
        public void UpdateType(int id, string name)
        {
            var db = new EquipmentContext();
            ActiveType = db.Type.Where(t => t.TypeId == id).First();
            ActiveType.Type = name;
            db.SaveChanges();
        }
        public void UpdateRarety(int id, string name, int max)
        {
            var db = new EquipmentContext();
            ActiveRarety = db.Rarety.Where(r => r.RaretyId == id).First();
            ActiveRarety.Rarety = name;
            ActiveRarety.MaxPoints = max;
            db.SaveChanges();
        }
        public void UpdateProperties(int id, int dur, int att, int def, int str, int dex, int inte)
        {
            var db = new EquipmentContext();
            if (ActiveItem.PropertyId != 0)
            {
                ActiveProperties = db.Properties.Where(i => i.PropertyId == id).First();
                ActiveProperties.Durability = dur;
                ActiveProperties.Attack = att;
                ActiveProperties.Defence = def;
                ActiveProperties.Strength = str;
                ActiveProperties.Dexterity = dex;
                ActiveProperties.Inteligence = inte;
            }
            else
            {
                AddProperties(ActiveItem.ItemId, dur, att, def, str, dex, inte);
                ActiveItem.PropertyId = ActiveItem.ItemId;
            }
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