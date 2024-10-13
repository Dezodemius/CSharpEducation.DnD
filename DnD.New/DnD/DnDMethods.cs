using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class DnDMethods
    {
        List<CharacterSheet> characters = new List<CharacterSheet>();
        private string FileСharaters = "characters.txt";
        
        public DnDMethods() 
        {
            characters = new List<CharacterSheet>();
            LoadFile();
        }

        public void AddCharacters(CharacterSheet character)
        {
            characters.Add(character);
            SaveFile();
        }

        public void FindCharacters(int id)
        {
            var character = characters.Find(i => i.Id == id);
            if (character != null)
            {
                Console.WriteLine($"Персонаж {character.Name} Расы {character.Race} существует");
            }
            else
            {
                Console.WriteLine("Такого персонажа не существует");
            }
        }
        private void SaveFile()
        {
            using (var writer = new StreamWriter(FileСharaters))
            {
                foreach (var character in characters)
                {
                    writer.WriteLine($"{character.Id};{character.Name};{character.Race};{character.Strenght};{character.Dexterity};{character.Сonstitution};" +
                        $"{character.Intelligence};{character.Wisdom};{character.Charisma};{character.HitPoints};{character.ArmorClass};{character.Speed}");
                }
            }
        }
        private void LoadFile()
        {
            if (File.Exists(FileСharaters))
            {
                var lines = File.ReadAllLines(FileСharaters);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 30)
                    {
                        characters.Add(new CharacterSheet(Convert.ToInt32(parts[0]), parts[1], parts[2], Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]), 
                            Convert.ToInt32(parts[5]), Convert.ToInt32(parts[6]), Convert.ToInt32(parts[7]), Convert.ToInt32(parts[8]), 
                            Convert.ToInt32(parts[9]), Convert.ToInt32(parts[10]), Convert.ToInt32(parts[11]),
                            Convert.ToInt32(parts[12]), Convert.ToInt32(parts[13]), Convert.ToInt32(parts[14]), Convert.ToInt32(parts[15]), Convert.ToInt32(parts[16]),
                            Convert.ToInt32(parts[17]), Convert.ToInt32(parts[18]), Convert.ToInt32(parts[19]), Convert.ToInt32(parts[20]), Convert.ToInt32(parts[21]), Convert.ToInt32(parts[22]),
                            Convert.ToInt32(parts[23]), Convert.ToInt32(parts[24]), Convert.ToInt32(parts[25]), Convert.ToInt32(parts[26]), Convert.ToInt32(parts[27]), Convert.ToInt32(parts[28]),
                            Convert.ToInt32(parts[29])));
                    }
                }
            }
        }

        private int maxSkills(int id)
        {
			var character = characters.Find(i => i.Id == id);
            List<int> numbers = new List<int> { character.Strenght, character.Dexterity, character.Сonstitution,
            character.Intelligence, character.Wisdom, character.Charisma};
            numbers.Sort();
			return (numbers.Max() - 10) / 2;
		}
	}
}
