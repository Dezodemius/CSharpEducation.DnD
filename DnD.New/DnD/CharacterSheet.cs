using DnD.Backpack;

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
		public int Acrobatics { get; set; }
		public int Animal_Handling { get; set; }
		public int Arcana { get; set; }
		public int Athletics { get; set; }
		public int Deception { get; set; }
		public int History { get; set; }
		public int Insight { get; set; }
		public int Intimidation { get; set; }
		public int Investigation { get; set; }
		public int Medicine { get; set; }
		public int Nature { get; set; }
		public int Perception { get; set; }
		public int Performance { get; set; }
		public int Persuasion { get; set; }
		public int Religion { get; set; }
		public int Sleight_Of_Hand { get; set; }
		public int Stealth { get; set; }
		public int Survival { get; set; }
		public List<Inventory> Items { get; set; }

        public CharacterSheet(int id, string name, string race, int strenght, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int speed, int acrobatics, int animal_Handling, int arcana, int athletics, int deception, int history, int insight,
		int intimidation, int investigation, int medicine, int nature, int perception, int performance, int persuasion, int religion, int sleight_Of_Hand, int stealth, int survival)
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
			this.Acrobatics = acrobatics;
			this.Animal_Handling = animal_Handling;
			this.Arcana = arcana;
			this.Athletics = athletics;
			this.Deception = deception;
			this.History = history;
			this.Insight = insight;
			this.Intimidation = intimidation;
			this.Investigation = investigation;
			this.Medicine = medicine;
			this.Nature = nature;
			this.Perception = perception;
			this.Performance = performance;
			this.Persuasion = persuasion;
			this.Religion = religion;
			this.Sleight_Of_Hand = sleight_Of_Hand;
			this.Stealth = stealth;
			this.Survival = survival;
			this.Items = new List<Inventory>();
        }

		public CharacterSheet(int id, string name, string race, int strenght, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int speed, int acrobatics, int animal_Handling, int arcana, int athletics, int deception, int history, int insight,
			int intimidation, int investigation, int medicine, int nature, int perception, int performance, int persuasion, int religion, int sleight_Of_Hand, int stealth, int survival, List<Inventory> items)
			: this(id, name, race, strenght, dexterity, constitution, intelligence, wisdom, charisma, hitPoints, armorClass, speed, acrobatics, animal_Handling, arcana, athletics, deception, history, insight, intimidation, investigation, medicine, nature, perception, performance, persuasion, religion, sleight_Of_Hand, stealth, survival)
		{
			this.Items = items;
		}
	}
}
