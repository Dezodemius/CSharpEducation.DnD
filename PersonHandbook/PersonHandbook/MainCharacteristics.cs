using System;
using System.Collections.Generic;

namespace PersonHandbook
{
  public class MainCharacteristics
  {
    public string Name { get; set; }
    
    public int Level { get; set; }

    public int Health { get; set; }

    public int Armor { get; set; }

    public Characteristics Characteristics { get; set; }

    public int ProficiencyBonus => (this.Level / 4) + 2; 
  }
}
