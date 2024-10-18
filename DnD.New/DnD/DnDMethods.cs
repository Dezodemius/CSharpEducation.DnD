using DnD.Backpack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    #region Класс исключения
    /// <summary>
    /// Исключение при домавлении существующего персонажа
    /// </summary>
    public class CharacterAlreadyExceprion : Exception
    {
        public CharacterAlreadyExceprion(string message) : base(message) { }
    }
    #endregion
    public class DnDMethods
        {
        #region Методы
            /// <summary>
            /// Лист персонажей
            /// </summary>
            List<CharacterSheet> characters = new List<CharacterSheet>();
            /// <summary>
            /// Файл куда сохранаются данные персонажа
            /// </summary>
        private string FileСharaters = "characters.txt";
            /// <summary>
            /// метод для считывает с файла персонажей
            /// </summary>
            public DnDMethods()
            {
                characters = new List<CharacterSheet>();
                LoadFile();
            }
            /// <summary>
            /// Метод для добавления персонажа
            /// </summary>
            public void AddCharacters(CharacterSheet character)
            {
                if (characters.Exists(c => c.Id == character.Id))
                {
                    throw new CharacterAlreadyExceprion("Пользователь с таким id уже существует");
                }
                characters.Add(character);
                SaveFile();
            }
            /// <summary>
            /// Метод для нахождения персонажа.
            /// </summary>
            /// <param name="id">Находит персонажа по id</param>
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
            /// <summary>
            /// Метод для нахождения персонажа в различных switch case
            /// </summary>
            /// <param name="id">Находит персонажа по id</param>
            /// <returns></returns>
            public CharacterSheet FindCharacterById(int id)
            {
                return characters.Find(i => i.Id == id);
            }
            /// <summary>
            /// Метод для добавления предмета в инвентарь персонажа
            /// </summary>
            /// <param name="item">добавление предмета</param>
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
                    Console.WriteLine($"Предмет {item.ItemName} успешно добавлен персонажу {character.Name}.");
                    Console.WriteLine($"Текущий вес рюкзака: {character.Items.Sum(i => i.Weight)}");
                }
                SaveFile(); //вызываем, чтоб сохранить инвентарь персу
            }
            /// <summary>
            /// Метод для удаление предмета
            /// </summary>
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
            /// <summary>
            /// Метод для вывода на экран предметов персонажа
            /// </summary>
            /// <param name="character"></param>
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
                    $"{item.ItemName}{(item.IsWeapon ? "(Оружие)" : " ")}")); //Теперь все инструменты из класса используются и выводится красиво
                    Console.WriteLine(itemsList);
                    double backpackWeigtForDisplay = character.Items.Sum(i => i.Weight);
                    Console.WriteLine($"Общий вес рюкзака: {backpackWeigtForDisplay}");
                }

            }
            /// <summary>
            /// Метод для возврата данных персонажа
            /// </summary>
            public CharacterSheet GetCharacters(int id) 
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
            /// <summary>
            /// Метод для сохранения данных персонажа в файл
            /// </summary>
            private void SaveFile()
            {
                using (var writer = new StreamWriter(FileСharaters))
                {
                    foreach (var character in characters)
                    {
                        List<string> itemStrings = new List<string>();
                        foreach (var item in character.Items)
                        {
                            itemStrings.Add($"{item.ItemName};{item.Description};{item.Weight}");
                        }
                        string itemsString = string.Join(",", itemStrings); //добавление инвентаря в файлик


                        writer.WriteLine($"{character.Id};{character.Name};{character.Race};{character.Strenght};{character.Dexterity};{character.Сonstitution};" +
                            $"{character.Intelligence};{character.Wisdom};{character.Charisma};{character.HitPoints};{character.ArmorClass};{character.Speed};" +
                            $"{character.Acrobatics};{character.Animal_Handling};{character.Arcana};{character.Athletics};{character.Deception};{character.History};" +
                            $"{character.Insight};{character.Intimidation};{character.Investigation};{character.Medicine};{character.Nature};{character.Perception};" +
                            $"{character.Performance};{character.Persuasion};{character.Religion};{character.Sleight_Of_Hand};{character.Stealth};{character.Survival};" +
                            $"{itemsString} ");
                    }
                }
            }
            /// <summary>
            /// Метод для считывания данных персонажа с файла
            /// </summary>
            private void LoadFile()
            {
                if (File.Exists(FileСharaters))
                {
                    var lines = File.ReadAllLines(FileСharaters);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(';');

                        if (parts.Length >= 30)
                        {

                            var items = new List<Inventory>();
                            if (parts.Length > 30)
                            {
                                var itemsPart = parts[30].Split(',');
                                foreach (var itemString in itemsPart)
                                {
                                    var itemParts = itemString.Split(';');
                                    if (itemParts.Length == 4)
                                    {
                                        var item = new Inventory(itemParts[0], itemParts[1], Convert.ToInt32(itemParts[2]), Convert.ToBoolean(itemParts[3]));
                                        items.Add(item);
                                    }
                                }
                            }

                            characters.Add(new CharacterSheet(
                            Convert.ToInt32(parts[0]),
                            parts[1],
                            parts[2],
                            Convert.ToInt32(parts[3]),
                            Convert.ToInt32(parts[4]),
                            Convert.ToInt32(parts[5]),
                            Convert.ToInt32(parts[6]),
                            Convert.ToInt32(parts[7]),
                            Convert.ToInt32(parts[8]),
                            Convert.ToInt32(parts[9]),
                            Convert.ToInt32(parts[10]),
                            Convert.ToInt32(parts[11]),
                            Convert.ToInt32(parts[12]),
                            Convert.ToInt32(parts[13]),
                            Convert.ToInt32(parts[14]),
                            Convert.ToInt32(parts[15]),
                            Convert.ToInt32(parts[16]),
                            Convert.ToInt32(parts[17]),
                            Convert.ToInt32(parts[18]),
                            Convert.ToInt32(parts[19]),
                            Convert.ToInt32(parts[20]),
                            Convert.ToInt32(parts[21]),
                            Convert.ToInt32(parts[22]),
                            Convert.ToInt32(parts[23]),
                            Convert.ToInt32(parts[24]),
                            Convert.ToInt32(parts[25]),
                            Convert.ToInt32(parts[26]),
                            Convert.ToInt32(parts[27]),
                            Convert.ToInt32(parts[28]),
                            Convert.ToInt32(parts[29]),
                            items
                        ));
                        }
                    }
                }
            }
            /// <summary>
            /// Метод формула, которая высчитывает значение модификатора
            /// </summary>
            public int maxSkills(int id)
            {
                var character = GetCharacters(id);
                List<int> numbers = new List<int> { character.Strenght, character.Dexterity, character.Сonstitution, character.Intelligence, character.Wisdom, character.Charisma };
                numbers.Sort();
                return (numbers.Max() - 10) / 2;
            }
            /// <summary>
            /// Метод для выведения модификаторв персонажей
            /// </summary>
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
        #endregion
        }

}


