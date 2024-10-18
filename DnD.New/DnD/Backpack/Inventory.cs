using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DnD.Backpack
{
    public class Inventory : Subject
    {
        public int Weight { get; set; }
        public bool IsWeapon { get; set; }


        [JsonConstructor]
        public Inventory(string itemName, string description, int weight, bool isWeapon)
            : base(itemName, description)  
        {
            this.Weight = weight;
            this.IsWeapon = isWeapon;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
        public override string GetInfo()
        {
            return base.GetInfo();
        }

    }



}
