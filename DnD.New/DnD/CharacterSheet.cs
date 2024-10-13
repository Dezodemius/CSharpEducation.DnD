using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class CharacterSheet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Сonstitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
		public int Speed { get; set; }
		public Skill Acrobatics { get; set; }
		public Skill Animal_Handling { get; set; }
		public Skill Arcana { get; set; }
		public Skill Athletics { get; set; }
		public Skill Deception { get; set; }
		public Skill History { get; set; }
		public Skill Insight { get; set; }
		public Skill Intimidation { get; set; }
		public Skill Investigation { get; set; }
		public Skill Medicine { get; set; }
		public Skill Nature { get; set; }
		public Skill Perception { get; set; }
		public Skill Performance { get; set; }
		public Skill Persuasion { get; set; }
		public Skill Religion { get; set; }
		public Skill Sleight_Of_Hand { get; set; }
		public Skill Stealth { get; set; }
		public Skill Survival { get; set; }


		public CharacterSheet(int id, string name, string race, int strenght, int dexterity, int constitution,
			int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int speed,
			int acrobatics, int animal_Handling, int arcana, int athletics, int deception, int history, int insight,
			int intimidation, int investigation, int medicine, int nature, int perception, int performance, int persuasion, int religion,
			int sleight_Of_Hand, int stealth, int survival)
        {
            this.Id = id;
            this.Name = name;
            this.Race = race;
            this.Strenght = strenght;
            this.Dexterity = dexterity;
            this.Сonstitution = constitution;
            this.Intelligence = intelligence;
            this.Wisdom = wisdom;
            this.Charisma = charisma;
            this.HitPoints = hitPoints;
            this.ArmorClass = armorClass;
            this.Speed = speed;
            this.Acrobatics = new Skill(dexterity, acrobatics);
			this.Animal_Handling = new Skill(wisdom, animal_Handling);
			this.Arcana = new Skill(intelligence, arcana);
			this.Athletics = new Skill(strenght, athletics);
			this.Deception = new Skill(charisma, deception);
			this.History = new Skill(intelligence, history);
			this.Insight = new Skill(wisdom, insight);
			this.Intimidation = new Skill(charisma, intimidation);
			this.Investigation = new Skill(intelligence, investigation);
			this.Medicine = new Skill(wisdom, medicine);
			this.Nature = new Skill(intelligence, nature);
			this.Perception = new Skill(wisdom, perception);
			this.Performance = new Skill(charisma, performance);
			this.Persuasion = new Skill(charisma, persuasion);
			this.Religion = new Skill(intelligence, religion);
			this.Sleight_Of_Hand = new Skill(dexterity, sleight_Of_Hand);
			this.Stealth = new Skill(dexterity, stealth);
			this.Survival = new Skill(wisdom, survival);
		}
    }
}
