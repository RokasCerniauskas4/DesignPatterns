using System;

namespace DesignPatterns
{
    public interface IDrinkAbs
    {
        string Name { get; }
        void Make();
    }

    public interface IDrinkFactory
    {
        IDrinkAbs CreateDrink(string kind);
    }

    public class HealthyDrink : IDrinkAbs
    {
        public string Name => "Healthy Drink";
        public void Make() => Console.WriteLine("Congrats, you chose a healthy lifestyle!");
    }

    public class EnergyDrinkAbs : IDrinkAbs
    {
        public string Name => "Energy Drink";
        public void Make() => Console.WriteLine("Enjoy your free energy!");
    }

    public class DepressionDrink : IDrinkAbs
    {
        public string Name => "Depression Drink";
        public void Make() => Console.WriteLine("Here is your drink, but maybe try sport instead?");
    }

    public class HealthyFactory : IDrinkFactory
    {
        private static readonly string[] Options = { "veggie", "fruit", "tea" };

        public IDrinkAbs CreateDrink(string kind)
        {
            if (Options.Contains(kind, StringComparer.OrdinalIgnoreCase))
                return new HealthyDrink();

            throw new ArgumentException($"Unsupported healthy drink kind: '{kind}'", nameof(kind));
        }
    }

    public class EnergyFactory : IDrinkFactory
    {
        private static readonly string[] Options = { "monster", "cafe", "red bull" };

        public IDrinkAbs CreateDrink(string kind)
        {
            if (Options.Contains(kind, StringComparer.OrdinalIgnoreCase))
                return new EnergyDrinkAbs();

            throw new ArgumentException($"Unsupported energy drink kind: '{kind}'", nameof(kind));
        }
    }

    public class DepressionFactory : IDrinkFactory
    {
        private static readonly string[] Options = { "bourbon", "vodka", "gin" };

        public IDrinkAbs CreateDrink(string kind)
        {
            if (Options.Contains(kind, StringComparer.OrdinalIgnoreCase))
                return new DepressionDrink();

            throw new ArgumentException($"Unsupported depression drink kind: '{kind}'", nameof(kind));
        }
    }

    public static class DrinkFactories
    {
        public static IDrinkFactory DecideYourDestiny(string mode) => mode?.ToLowerInvariant() switch
        {
            "healthy" => new HealthyFactory(),
            "energy" => new EnergyFactory(),
            "depression" => new DepressionFactory(),
            _ => throw new ArgumentException($"Unknown mode '{mode}'", nameof(mode))
        };
    }
}
