using DnD.Backpack;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        private string FileСharaters = "characters.json";
        
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

        public CharacterSheet FindCharacterById(int id)
        {
            return characters.Find(i => i.Id == id);
        }

        public void AddItem(int id, Inventory item)
        {
            
            var character = characters.Find(i => i.Id == id);

            
            if (character == null)
            {
                Console.WriteLine($"Персонаж с id {id} не найден.");
                return;
            }

            //Добавление веса рюкзака, подпись оружия
            int weaponCount = character.Items.Count(i => i.IsWeapon);
            double backpackWeigt = character.Items.Sum(i => i.Weight) + item.Weight;

            if (backpackWeigt > 20)
            {
                Console.WriteLine("Рюкзак персонажа переполнен");
                return;
            }

            
            if (item.IsWeapon && weaponCount >= 2) 
            {
                Console.WriteLine($"У персонажа {character.Name} уже два оружия, добавление не возможно");
                return;
            }

            
            if (character.Items.Exists(i => i.ItemName == item.ItemName))
            {
                Console.WriteLine($"Предмет {item.ItemName} уже есть у персонажа {character.Name}.");
            }
            else
            {
               
                character.Items.Add(item);
                SaveFile(); //вызываем, чтоб сохранить инвентарь персу
                Console.WriteLine($"Предмет {item.ItemName} успешно добавлен персонажу {character.Name}.");
                Console.WriteLine($"Текущий вес рюкзака: {character.Items.Sum(i => i.Weight)}");
    
            }
            
        }

        public void RemoveItem(int id, Inventory item)
        {
            var character = characters.Find(i => i.Id == id);

            if (character == null)
            {
                Console.WriteLine($"Персонаж с id {id} не найден.");
                return;
            }

            var itemToRemove = character.Items.Find(i => i.ItemName == item.ItemName);

            if (itemToRemove != null)
            {
                character.Items.Remove(itemToRemove);
                Console.WriteLine($"Предмет {item.ItemName} удален у персонажа {character.Name}.");
            }
            else
            {
                Console.WriteLine($"Предмет {item.ItemName} не найден у персонажа {character.Name}.");
            }
        }




        public void DisplayItems(CharacterSheet character)
        {
            if (character.Items.Count == 0)
            {
                Console.WriteLine($"{character.Name} не имеет предметов.");
            }
            else
            {
                Console.WriteLine($"Инвентарь персонажа {character.Name}:");
                string itemsList = string.Join(", ", character.Items.Select(item =>
                $"{item.ItemName}{(item.IsWeapon ? "(Оружие)" : " " )}")); //Теперь все инструменты из класса используются и выводится красиво
                Console.WriteLine(itemsList);
                double backpackWeigtForDisplay = character.Items.Sum(i => i.Weight);
                Console.WriteLine($"Общий вес рюкзака: {backpackWeigtForDisplay}");
            }

        }
    


    

        public CharacterSheet GetCharacters (int id) //Добавил метод возврата данных персонажа по id
        {
            var character = characters.Find(i => i.Id == id);
            if (character != null)
            {
                return character;
            }
            else
            {
                Console.WriteLine("Такого персонажа не существует");
                return null;
            }
        }
        private void SaveFile()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(characters, jsonOptions);

            File.WriteAllText(FileСharaters, jsonString);
        }


        private void LoadFile()
        {
            if (File.Exists(FileСharaters)) 
            {
               
                var jsonString = File.ReadAllText(FileСharaters);
                
                characters = JsonSerializer.Deserialize<List<CharacterSheet>>(jsonString);

            }
            else
            {
                characters = new List<CharacterSheet>();    
            }
        }

        public int maxSkills(int id)
		{
			var character = GetCharacters(id);
			List<int> numbers = new List<int> { character.Strenght, character.Dexterity, character.Constitution, character.Intelligence, character.Wisdom, character.Charisma};
			numbers.Sort();
			return (numbers.Max() - 10) / 2;
		}

		public int Modification(int id, string skill)
		{
			var character = GetCharacters(id);

			int modification = 0;
			switch (skill)
			{
				case "acrobatics":
				case "sleight_Of_Hand":
				case "stealth":
					modification = (character.Dexterity - 10) / 2;
					break;
				case "animal_Handling":
				case "insight":
				case "medicine":
				case "perception":
				case "survival":
					modification = (character.Wisdom - 10) / 2;
					break;
				case "arcana":
				case "history":
				case "investigation":
				case "nature":
				case "religion":
					modification = (character.Intelligence - 10) / 2;
					break;
				case "athletics":
					modification = (character.Strenght - 10) / 2;
					break;
				case "deception":
				case "intimidation":
				case "performance":
				case "persuasion":
					modification = (character.Charisma - 10) / 2;
                    break;
                default:
					break;
			}
			return modification;
		}
	}
     
 }

