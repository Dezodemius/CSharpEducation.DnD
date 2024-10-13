using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
	public class Skill
	{
		public int Value { get; set; }
		public int Modificator { get; }

		public Skill(int Charecteristic, int value) 
		{
			this.Value = value;
			this.Modificator = (Charecteristic - 10) / 2;
		}
	}
}
