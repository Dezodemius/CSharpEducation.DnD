using System;


namespace PersonHandbook
{
  public class Character
  {
    #region Поля и Свойства
    public string Name { get; set; }

    public Race race { get; set; }

    public int ProficiencyBonus => (this.Level / 4) + 2;

    public Weapon EquippedWeapon { get; set; }

    public int Armor { get; set; }

    public int Health { get; set; }

    public int Level { get; set; }

    private Dice dice;
    #endregion

    #region Методы

    public void AddWeapon(Weapon w)
    {
      EquippedWeapon = new Weapon(w.Name, w.DamageDice, w.DamageType);
    }

    public int GetAttackRoll()
    {
      // Атака с использованием Силы
      return dice.Roll(20) + race.Strength.Modificator + ProficiencyBonus;
    }

    public int GetDamage()
    {
      // Урон от оружия
      return EquippedWeapon.RollDamage() + race.Strength.Modificator;
    }

    public int GetArmorClass()
    {
      // Класс доспехов без доспеха
      return 10 + race.Dexterity.Modificator;
    }
    #endregion

    #region Конструкторы
    public Character(string name, Race enterRace, int level, int healht)
    {
      Name = name;
      race = enterRace;
      Level = level;
      Health = healht;
      Armor = 10 + race.Dexterity.Modificator;
      dice = new Dice();
    }

    #endregion
  }
}
