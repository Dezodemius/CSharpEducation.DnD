using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Backpack
{
    public abstract class Subject
    {
        #region Поля и свойства
        public string ItemName { get; set; }

        public string Description { get; set; }
        #endregion

        #region Конструктор
        public Subject(string itemname, string description)
        {
            ItemName = itemname;
            Description = description;
        }
        #endregion

        #region Методы
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {ItemName}");
            Console.WriteLine($"Description: {Description}");
        }
        public virtual string GetInfo()
        {
            return $"{ItemName}: {Description}";
        }
        #endregion
    }
}
