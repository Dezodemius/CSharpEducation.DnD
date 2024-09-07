using System;

public class Weapon
{
    public string Name { get; set; }
    public int DamageDice { get; set; } // Например, 6 для 1d6
    public string DamageType { get; set; } // Тип урона, например, "колющий"

    public Weapon(string name, int damageDice, string damageType)
    {
        Name = name;
        DamageDice = damageDice;
        DamageType = damageType;
    }

    public int RollDamage()
    {
        Random rand = new Random();
        return rand.Next(1, DamageDice + 1); // Ролл урона
    }
}

public class Character
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int ProficiencyBonus { get; set; } // Бонус мастерства
    public Weapon EquippedWeapon { get; set; }

    public Character(string name, int strength, int dexterity, int proficiencyBonus)
    {
        Name = name;
        Strength = strength;
        Dexterity = dexterity;
        ProficiencyBonus = proficiencyBonus;
    }

    public int GetAttackRoll()
    {
        // Атака с использованием Силы
        return RollD20() + GetStrengthModifier() + ProficiencyBonus;
    }

    public int GetDamage()
    {
        // Урон от оружия
        return EquippedWeapon.RollDamage() + GetStrengthModifier();
    }

    public int GetArmorClass()
    {
        // Класс доспехов без доспеха
        return 10 + GetDexterityModifier();
    }

    private int GetStrengthModifier()
    {
        return (Strength - 10) / 2; // Модификатор Силы
    }

    private int GetDexterityModifier()
    {
        return (Dexterity - 10) / 2; // Модификатор Ловкости
    }

    private int RollD20()
    {
        Random rand = new Random();
        return rand.Next(1, 21); // Ролл d20
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования
        Character hero = new Character("Герой", 16, 14, 2);
        hero.EquippedWeapon = new Weapon("Меч", 6, "резущий");

        Console.WriteLine($"{hero.Name} атакует с оружием {hero.EquippedWeapon.Name}.");
        int attackRoll = hero.GetAttackRoll();
        Console.WriteLine($"Результат атаки: {attackRoll}");

        int damage = hero.GetDamage();
        Console.WriteLine($"Урон: {damage}");
        Console.WriteLine($"Класс доспехов: {hero.GetArmorClass()}");
    }
}