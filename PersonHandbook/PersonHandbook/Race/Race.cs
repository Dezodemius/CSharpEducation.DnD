using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandbook
{
  public class Race : Characteristics
  {
    public Race(int strength, int dexterity, int physique, int intellect, int wisdom, int charisma):base(strength, dexterity, physique, intellect, wisdom, charisma)
    {

    }
  }
}
