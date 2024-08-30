using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandbook
{
  /// <summary>
  /// Метод описывает характеристики персонажа.
  /// Работает с классом Characteristic
  /// </summary>
  public class Characteristics
  {
    #region Поля и Свойства

    public Characteristic Strength { get; set; }

    public Characteristic Dexterity { get; set; }

    public Characteristic Physique { get; set; }

    public Characteristic Intellect { get; set; }

    public Characteristic Wisdom { get; set; }

    public Characteristic Charisma { get; set; }

    #endregion


    private void AddSkills()
    {
      Strength.Skills.Add(new Skill("Athletics", 0));
      Dexterity.Skills.Add(new Skill("Acrobatics", 0));
      Dexterity.Skills.Add(new Skill("Sleight of hand", 0));
      Dexterity.Skills.Add(new Skill("Stealth", 0));
      Intellect.Skills.Add(new Skill("History", 0));
      Intellect.Skills.Add(new Skill("Magic", 0));
      Intellect.Skills.Add(new Skill("Nature", 0));
      Intellect.Skills.Add(new Skill("Investigation", 0));
      Intellect.Skills.Add(new Skill("Religion", 0));
      Wisdom.Skills.Add(new Skill("Perception", 0));
      Wisdom.Skills.Add(new Skill("Survival", 0));
      Wisdom.Skills.Add(new Skill("Medicine", 0));
      Wisdom.Skills.Add(new Skill("Insight", 0));
      Wisdom.Skills.Add(new Skill("Animal care", 0));
      Charisma.Skills.Add(new Skill("Performance", 0));
      Charisma.Skills.Add(new Skill("Intimidation", 0));
      Charisma.Skills.Add(new Skill("Deception", 0));
      Charisma.Skills.Add(new Skill("Conviction", 0));
    }

    public void UpdateSkillsValues(int proficiencyBonus)
    {
      foreach(var i in Strength.Skills)
      {
        i.UpdateValue(Strength.Modificator,proficiencyBonus);
      }
      foreach (var i in Dexterity.Skills)
      {
        i.UpdateValue(Dexterity.Modificator, proficiencyBonus);
      }
      foreach (var i in Physique.Skills)
      {
        i.UpdateValue(Physique.Modificator, proficiencyBonus);
      }
      foreach (var i in Intellect.Skills)
      {
        i.UpdateValue(Intellect.Modificator, proficiencyBonus);
      }
      foreach (var i in Wisdom.Skills)
      {
        i.UpdateValue(Wisdom.Modificator, proficiencyBonus);
      }
      foreach (var i in Charisma.Skills)
      {
        i.UpdateValue(Charisma.Modificator, proficiencyBonus);
      }
    }
    #region Конструкторы

    public Characteristics()
    {
      Strength.Value = 1;

      Dexterity.Value = 1;

      Physique.Value = 1;

      Intellect.Value = 1;

      Wisdom.Value = 1;

      Charisma.Value = 1;

      AddSkills();
    }

    public Characteristics(int strength, int dexterity, int physique, int intellect, int wisdom, int charisma)
    {
      Strength.Value = strength;
      Dexterity.Value = dexterity;
      Physique.Value = physique;
      Intellect.Value = intellect;
      Wisdom.Value = wisdom;
      Charisma.Value = charisma;

      AddSkills();
    }

    #endregion
  }
}
