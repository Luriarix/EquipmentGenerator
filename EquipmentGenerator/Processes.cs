 using EquipmentDatabase;
using Microsoft.EntityFrameworkCore;
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
            if (ActiveItem.ItemProperty != null)
            {
                SelectedProperties(ActiveItem.ItemProperty);
            }
        }

        public Types ActiveType { get; set; }
        public void SelectedType(object type)
        {
            var db = new EquipmentContext();
            if (type != null)
                ActiveType = db.Type.Where(t => t == type).First();
            else
                ActiveType = null;
        }


        public Rareties ActiveRarety { get; set; }
        public void SelectedRarety(object rarety)
        {
            var db = new EquipmentContext();
            if (rarety != null)
                ActiveRarety = db.Rarety.Where(r => r == rarety).First();
            else
                ActiveRarety = null;
        }


        public Properties ActiveProperties { get; set; }
        public void SelectedProperties(object property)
        {
            var db = new EquipmentContext();
            ActiveProperties = db.Properties.Where(p => p == property).First();
        }



        public List<Item> ReadItemList()
        {
            var db = new EquipmentContext();
            return db.Items.Include(t => t.ItemType).Include(r => r.CommonItemRarety).Include(p => p.ItemProperty).ToList();
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

        public void CleanUp()
        {
            var db = new EquipmentContext();
            var vb =new EquipmentContext();
            bool verify = false;
            foreach (var p in vb.Properties)
            {
                foreach (var i in db.Items.Include(p => p.ItemProperty))
                {
                    if (i.ItemProperty != null)
                    {
                        if (p.PropertyId == i.ItemProperty.PropertyId)
                        {
                            verify = true;
                        }
                    }
                }
                if (verify == false)
                {
                    vb.Properties.Remove(p);
                }
                verify = false;
            }
            vb.SaveChanges();
        }

        private int ItemPropertiesAmount()
        {
            return ((ActiveItem.ItemProperty.Attack + ActiveItem.ItemProperty.Defence) / 2 + (ActiveItem.ItemProperty.Dexterity + ActiveItem.ItemProperty.Inteligence + ActiveItem.ItemProperty.Strength));
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

        public void AddProperties(int dur, int att, int def, int str, int dex, int inte)
        {
            var db = new EquipmentContext();
            db.Add(new Properties
            {
                Durability = dur,
                Attack = att,
                Defence = def,
                Strength = str,
                Dexterity = dex,
                Inteligence = inte
            });
            db.SaveChanges();
            SelectedProperties( db.Properties.ToList().Last());
        }


        public void UpdateItem(string name)
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i == ActiveItem).Include(t => t.ItemType).Include(r => r.CommonItemRarety).Include(p => p.ItemProperty).First();
            ActiveItem.ItemName = name;
            if (ActiveType != null & ActiveType != ActiveItem.ItemType)
            {
                ActiveItem.ItemType = ActiveType;
            }
            if (ActiveItem.CommonItemRarety != null)
            {
                var i = db.Rarety.OrderBy(r => r.MaxPoints);
                foreach (var r in db.Rarety)
                {
                    if (r.MaxPoints > ItemPropertiesAmount())
                    {
                        ActiveItem.CommonItemRarety = r;
                        break;
                    }
                }
                if (ActiveItem.CommonItemRarety == null)
                    ActiveItem.CommonItemRarety = db.Rarety.Max();
            }
            db.SaveChanges();
        }
        public void UpdateType(string name)
        {
            var db = new EquipmentContext();
            ActiveType = db.Type.Where(t => t == ActiveType).First();
            ActiveType.Type = name;
            db.SaveChanges();
        }
        public void UpdateRarety(string name, int max)
        {
            var db = new EquipmentContext();
            ActiveRarety = db.Rarety.Where(r => r == ActiveRarety).First();
            ActiveRarety.Rarety = name;
            ActiveRarety.MaxPoints = max;
            db.SaveChanges();
        }
        public void UpdateProperties(int dur, int att, int def, int str, int dex, int inte)
        {
            var db = new EquipmentContext();
            if (ActiveItem.ItemProperty != null)
            {
                ActiveProperties = db.Properties.Where(i => i.PropertyId == ActiveItem.ItemProperty.PropertyId).First();
                ActiveProperties.Durability = dur;
                ActiveProperties.Attack = att;
                ActiveProperties.Defence = def;
                ActiveProperties.Strength = str;
                ActiveProperties.Dexterity = dex;
                ActiveProperties.Inteligence = inte;
            }
            else
            {
                AddProperties(dur, att, def, str, dex, inte);
                UpdateItemProperties();
            }
            db.SaveChanges();
        }

        public void UpdateItemProperties()
        {
            var db = new EquipmentContext();
            ActiveItem = db.Items.Where(i => i == ActiveItem).Include(t => t.ItemType).Include(r => r.CommonItemRarety).Include(p => p.ItemProperty).First();
            ActiveItem.ItemProperty = ActiveProperties;
            db.SaveChanges();
        }





        public void RemoveItem()
        {
            var db = new EquipmentContext();
                db.Remove(ActiveItem);

            if (ActiveItem.ItemProperty != null)
                db.Remove(ActiveProperties);
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