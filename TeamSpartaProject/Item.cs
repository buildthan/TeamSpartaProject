using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTeamProject
{
    public class Item
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int Effect { get; set; }
        public string ItemType { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public Item(string name, string info, int effect, string itemType, int price, int count)
        {
            Name = name;
            Info = info;
            Effect = effect;
            ItemType = itemType;
            Price = price;
            Count = count;
        }

    }

}
