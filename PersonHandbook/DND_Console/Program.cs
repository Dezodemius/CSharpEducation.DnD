using System;
using System.Collections.Generic;
using PersonHandbook;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace DND_Console
{
  class Program
  {
    static List<Character> character = new List<Character>();
    static void ShowCharacterInConsole(List<Character> characters)
    {
      if(characters.Count==0)
      {
        Console.WriteLine("Нет созданных персонажей");
      }
      else
      {
        int k = 1;
        foreach(var i in characters)
        {
          Console.WriteLine(string.Format("{3}: Имя: {0}; Раса: {1}; Уровень:{2}.", i.Name, i.race.GetType(), i.Level,k));
          k++;
        }
        Console.WriteLine();
      }
    }

    static Character CreateCharacter()
    {
      Console.WriteLine(" Создание персонажа ");

      Console.WriteLine("Введите имя персонажа:");
      string name = Console.ReadLine();
      Console.WriteLine();
      Console.WriteLine("Выберите расу персонажа:");
      Console.WriteLine("1: Человек");
      Console.WriteLine("2: Ельф");
      Console.WriteLine("3: Гном");
      Console.WriteLine("4: Орк");
      int userChoose = int.Parse(Console.ReadLine());
      Race r = new Race(1,1,1,1,1,1);
      switch (userChoose)
      {
        case 1:
          r = new Human();
          break;
        case 2:
          r = new Elf();
          break;
        case 3:
          r = new Gnome();
          break;
        case 4:
          r = new Orc();
          break;
        default:

          break;
      }
      Console.WriteLine();

      Console.WriteLine("Введите уровень персонажа:");
      int level = int.Parse(Console.ReadLine());

      Console.WriteLine("Введите уровень здоровья персонажа:");
      int healthLevel = int.Parse(Console.ReadLine());
      Character character = new Character(name,r,level,healthLevel);

      Console.WriteLine();
      Console.WriteLine("Создайте оружие персонажа:");
      Console.WriteLine("     Введите название оружия:");
      string nameW = Console.ReadLine();
      Console.WriteLine("     Введите кость для оружия:");
      int diceW = int.Parse(Console.ReadLine());
      Console.WriteLine("     Введите тип урона оружия:");
      string typeW = Console.ReadLine();
      character.AddWeapon(new Weapon(nameW, diceW, typeW));
      return character;
    }

    static void OpenPersonState(List<Character> Characters)
    {
      Console.WriteLine(" Открыть карточку персонажа ");

      ShowCharacterInConsole(Characters);
      Console.WriteLine("Введите номер персонажа:");
      int characterIndex = int.Parse(Console.ReadLine());
      Console.WriteLine();

      Console.WriteLine("Имя персонажа: "+Characters[characterIndex].Name);
      Console.WriteLine("Раса персонажа: " + Characters[characterIndex].race.GetType());
      Console.WriteLine("Уровень персонажа: " + Characters[characterIndex].Level);
      Console.WriteLine("Здоровье персонажа: " + Characters[characterIndex].Health);
      Console.WriteLine("Оружие персонажа: ");
      Console.WriteLine("     Название: " + Characters[characterIndex].EquippedWeapon.Name);
      Console.WriteLine("     Кубик урона: " + Characters[characterIndex].EquippedWeapon.DamageDice);
      Console.WriteLine("     Тип урона: " + Characters[characterIndex].EquippedWeapon.DamageType);
      Console.WriteLine("Бонус мастерства персонажа: " + Characters[characterIndex].ProficiencyBonus);
      Console.WriteLine("Характеристики персонажа: ");
      Console.WriteLine("     Сила: " + Characters[characterIndex].race.Strength.Value);
      Console.WriteLine("     Сила модификатор: " + Characters[characterIndex].race.Strength.Modificator);
      Console.WriteLine("     Ловкость: " + Characters[characterIndex].race.Dexterity.Value);
      Console.WriteLine("     Ловкость модификатор: " + Characters[characterIndex].race.Strength.Modificator);
      Console.WriteLine("     Телосложение: " + Characters[characterIndex].race.Physique.Value);
      Console.WriteLine("     Телосложение модификатор: " + Characters[characterIndex].race.Physique.Modificator);
      Console.WriteLine("     Интеллект: " + Characters[characterIndex].race.Intellect.Value);
      Console.WriteLine("     Интеллект модификатор: " + Characters[characterIndex].race.Intellect.Modificator);
      Console.WriteLine("     Мудрость: " + Characters[characterIndex].race.Wisdom.Value);
      Console.WriteLine("     Мудрость модификатор: " + Characters[characterIndex].race.Wisdom.Modificator);
      Console.WriteLine("     Харизма: " + Characters[characterIndex].race.Charisma.Value);
      Console.WriteLine("     Харизма модификатор: " + Characters[characterIndex].race.Charisma.Modificator);

      Console.WriteLine();
    }

    static void DeletePerson(List<Character> Characters)
    {
      Console.WriteLine(" Удалить карточку персонажа ");

      ShowCharacterInConsole(Characters);
      Console.WriteLine("Введите номер персонажа:");
      int characterIndex = int.Parse(Console.ReadLine());
      Characters.Remove(Characters[characterIndex]);

      Console.WriteLine("Персонаж удален!!");
      Console.WriteLine();
    }

    static async Task SaveCharactersAsync(List<Character> characters)
    {
      Console.WriteLine(" Сохранение данных ");

      
      // сохранение данных
      using (FileStream fs = new FileStream("characters.json", FileMode.OpenOrCreate))
      {

        await JsonSerializer.SerializeAsync<List<Character>>(fs, characters);


        Console.WriteLine("Данные были сохранены.");
      }
    }

    static async Task LoadCharactersAsync()
    {
      Console.WriteLine(" Открытие данных ");


      using (FileStream fs = new FileStream("characters.json", FileMode.OpenOrCreate))
      {
        var inputCharacters = await JsonSerializer.DeserializeAsync<List<Character>>(fs);

        character = inputCharacters;
        Console.WriteLine("Данные открыты.");
      }
    }


    static void Main(string[] args)
    {
      
      Console.WriteLine("DND-Console.");
      bool exit = false;
      do
      {
        Console.WriteLine("Введите команду:");
        Console.WriteLine("1: Показать список персонажей");
        Console.WriteLine("2: Создать персонажа");
        Console.WriteLine("3: Открыть карточку персонажа");
        Console.WriteLine("4: Удалить персонажа");
        Console.WriteLine("5: Сохранить персонажей");
        Console.WriteLine("6: Открыть файл сохранения");
        int userChose = int.Parse(Console.ReadLine());
        switch (userChose)
        {
          case 1:
            ShowCharacterInConsole(character);
            break;
          case 2:
            character.Add(CreateCharacter());
            break;
          case 3:
            OpenPersonState(character);
            break;
          case 4:
            DeletePerson(character);
            break;
          case 5:
            _ = SaveCharactersAsync(character);
            break;
          case 6:
            _ = LoadCharactersAsync();
            break;
          default:
            exit = true;
            break;
        }
      } while (!exit);
    }
  }
}
