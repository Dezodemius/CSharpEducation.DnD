using System;

namespace PersonHandbook
{
  public class Dice
  {
    private Random dndrandom;

    public Dice()
    {
      dndrandom = new Random();
    }

    public int Roll(int sides)
    {
      if (sides < 1)
      {
        throw new ArgumentException("Количество граней должно быть больше 0.", nameof(sides));
      }

      return dndrandom.Next(1, sides + 1);
    }

  }
}
