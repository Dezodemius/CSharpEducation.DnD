using System;

namespace PersonHandbook
{
  public class Weapon
  {
    public string Name { get; set; }
    public int DamageDice { get; set; } // Например, 6 для 1d6
    public string DamageType { get; set; } // Тип урона, например, "колющий"

    public Weapon(string name, int damageDice, string damageType)
    {
      Name = name;
      DamageDice = damageDice;
      DamageType = damageType;
    }

    public int RollDamage()
    {
      Dice dice = new Dice();
      return dice.Roll(DamageDice); // Ролл урона
    }
  }
}
