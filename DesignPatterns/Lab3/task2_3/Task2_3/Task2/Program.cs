using Task2.Command;
using Task2.Models;
using Task2.Strategy;
using Task2.TemplateMethod;

namespace Task2;

internal static class Program
{
    static void Main()
    {
        var car = new Car("BMW", new NormalMode());

        Console.WriteLine("=== STRATEGY (Mode) ===");
        Console.WriteLine(car);
        car.Mode = new EcoMode();
        car.Accelerate(10);
        Console.WriteLine("After ECO accelerate(10): " + car);

        car.Mode = new SportMode();
        car.Accelerate(10);
        Console.WriteLine("After SPORT accelerate(10): " + car);

        Console.WriteLine();
        Console.WriteLine("=== COMMAND ===");
        var queue = new CommandQueue();
        queue.Add(new SetModeCommand(car, new NormalMode()));
        queue.Add(new AccelerateCommand(car, 10));
        queue.Add(new AccelerateCommand(car, 10));
        queue.Add(new BrakeCommand(car, 5));

        queue.RunAll(cmdName =>
        {
            Console.WriteLine($"Executing: {cmdName} | Before: {car}");
        });

        Console.WriteLine("After commands: " + car);

        Console.WriteLine();
        Console.WriteLine("=== TEMPLATE METHOD ===");
        var city = new CityTrip();
        var highway = new HighwayTrip();

        city.Run(car);
        Console.WriteLine("After CityTrip: " + car);

        highway.Run(car);
        Console.WriteLine("After HighwayTrip: " + car);
    }
}