using System;

namespace DesignPatterns
{
    public interface IDrink
    {
        string Name { get; }
        void Make();
    }

    public class VeggieDrink : IDrink
    {
        public string Name => "Veggie drink";
        public void Make() => Console.WriteLine("Healthy no sugar drink with tomatoes and onions");
    }

    public class FruitDrink : IDrink
    {
        public string Name => "Fruit drink";
        public void Make() => Console.WriteLine("Healthy no sugar drink with apples and oranges");
    }

    public class EnergyDrink : IDrink
    {
        public string Name => "Energy drink";
        public void Make() => Console.WriteLine("Red bull gives you wings, but its not healthy!!!");
    }

    public static class DrinkFactory
    {
        public static IDrink Create(string kind)
        {
            if (string.Equals(kind, "veggie")) return new VeggieDrink();
            if (string.Equals(kind, "fruit"))  return new FruitDrink();
            if (string.Equals(kind, "energy")) return new EnergyDrink();
            throw new ArgumentException($"Sorry factory does not produce this kind: '{kind}' of drinks :(", 
                nameof(kind));
        }
    }
}
