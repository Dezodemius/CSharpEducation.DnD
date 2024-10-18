using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Backpack
{
    public class Inventory : Subject
    {
        #region Поля и свойства
        public int Weight { get; set; }
        public bool IsWeapon { get; set; }
        #endregion 

        #region Конструктор
        public Inventory(string itemname, string discription, int weight,  bool isWeapon) : base(itemname, discription)
        {

            Weight = weight;
            IsWeapon = isWeapon;
        }
        #endregion

        #region Методы
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
        public override string GetInfo()
        {
            return base.GetInfo();
        }
        #endregion
    }
}
