using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandbook
{
  /// <summary>
  /// Класс описывает логику характеристики персонажа.
  /// Имеет, значение характеристики, модификатор характеристики, список навыков
  /// </summary>
  public class Characteristic
  {
    public int Value { get; set; }

    public int Modificator => (this.Value - 10) / 2;

    public List<Skill> Skills { get; set; }
  }
}
