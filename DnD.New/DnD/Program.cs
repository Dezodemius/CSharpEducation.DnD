using System;
using System.Collections;
using System.Collections.Generic;

namespace DnD
{
    public class Program
    {
        static void Main(string[] args)
        {
            DnDMethods dnDMethods = new DnDMethods();

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Добавить персонажа");
                Console.WriteLine("2. Получить персонажа по id");
                Console.WriteLine("3. Подготовить лист персонажа в PDF формате");

                int choice  = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.Write("Введите Id персонажа: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите имя персонажа: ");
                        string name = Console.ReadLine();

                        string[] races = { "Человек", "Эльф", "Гном", "Хоббит", "Дварф", "Орк","Гоблин", "Удмурт", "Татарин"};
                        Console.WriteLine("Выберите расу персонажа:");
                        for (int i = 0; i < races.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {races[i]}");
                        }
                        int raceChoice;
                        do
                        {
                            Console.Write("Введите номер расы: ");
                            raceChoice = Convert.ToInt32(Console.ReadLine());
                        } while (raceChoice < 1 || raceChoice > races.Length);
                        string race = races[raceChoice - 1];

                        Console.Write("Введите значение силы: ");
                        int strength = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение ловкости: ");
                        int agility = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение телосложения: ");
                        int physique = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение интелекта: ");
                        int intelligence = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение мудрости: ");
                        int wisdom = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение харизмы: ");
                        int charisma = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение хитов: ");
                        int hitPoints = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение класса брони: ");
                        int armorClass = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите значение скорости: ");
                        int speed = Convert.ToInt32(Console.ReadLine());

						string[] skills =
                        {
                            "Акробатика",
                            "Уход за животными",
                            "Магия",
							"Атлетика",
							"Обман",
							"История",
                            "Анализ",
                            "Запугивание",
                            "Проницательность",
                            "Медицина",
                            "Природа",
                            "Внимательность",
                            "Выступление",
                            "Убеждение",
                            "Религия",
                            "Ловкость рук",
                            "Скрытность",
                            "Выживание"
						};
                        int[] valueSkills = new int[skills.Length];

						int skillChoice;
						do
						{
							Console.WriteLine("Выберите нывыки:\nМаксимальное значение 2, приповторном выборе сбрасывается до 0");
							for (int i = 0; i < skills.Length; i++)
							{
								Console.WriteLine($"{i + 1}. {skills[i]} = {valueSkills[i]}");
							}
							Console.WriteLine("0. Сохранить навыки");
							Console.Write("Введите номер нывыка: ");
							skillChoice = Convert.ToInt32(Console.ReadLine());
                            --skillChoice;

							if (skillChoice > -1 && skillChoice < skills.Length)
                            {
                                valueSkills[skillChoice]++;
                                if (valueSkills[skillChoice] > 2)
                                    valueSkills[skillChoice] = 0;
							}
						} while (skillChoice != -1);


						dnDMethods.AddCharacters(new CharacterSheet(id, name, race, strength, agility, physique, intelligence, wisdom, charisma, hitPoints, armorClass,speed, valueSkills[0], valueSkills[1], valueSkills[2], valueSkills[3], valueSkills[4], valueSkills[5], valueSkills[6], valueSkills[7], valueSkills[8], valueSkills[9], valueSkills[10], valueSkills[11], valueSkills[12], valueSkills[13], valueSkills[14], valueSkills[15], valueSkills[16], valueSkills[17]));
                        Console.WriteLine($"Персонаж {name} добавлен");
                        break;
                   
                    case 2:
                        Console.WriteLine("Введите id персонажа");
                        int findId = Convert.ToInt32(Console.ReadLine());
                        dnDMethods.FindCharacters(findId);
                        break; 
                }
            }
        }
    }
}
