using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandbook
{
  /// <summary>
  /// Класс описывающий навыки.
  /// У навыка есть имя, значение, которое высчитывается
  /// </summary>
  public class Skill
  {
    public string Name { get; set; }
    public int Value { get; set; }

    /// <summary>
    /// Метод вычисления значения навыка
    /// </summary>
    /// <param name="characteristicValue">Значение значимой характеристики.</param>
    /// <param name="modificatorValue">Значение модификатора</param>
    public void UpdateValue(int characteristicModificatorValue, int ProficiencyBonus)
    {
      Value = characteristicModificatorValue + ProficiencyBonus;
    }

    public Skill(string name, int value)
    {
      Name = name;
      Value = value;
    }
  }
}
