using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentDatabase
{
    public partial class Item
    {
        public override string ToString()
        {
            return $"{ItemId} {ItemName}";
        }
    }
}
