namespace task1;

public class CarModel
{
    public string Brand { get; }
    public string Model { get; }
    public string Color { get; }

    public CarModel(string brand, string model, string color)
    {
        Brand = brand;
        Model = model;
        Color = color;
    }

    public void ShowInfo(string licensePlate, int parkingSpot)
    {
        Console.WriteLine(
            $"Car {licensePlate} at spot {parkingSpot}: {Brand} {Model} ({Color})");
    }
}

public class CarModelFactory
{
    private readonly Dictionary<string, CarModel> _cache = new();

    public CarModel GetCarModel(string brand, string model, string color)
    {
        var key = $"{brand}_{model}_{color}".ToLowerInvariant();

        if (!_cache.TryGetValue(key, out var carModel))
        {
            carModel = new CarModel(brand, model, color);
            _cache[key] = carModel;
            Console.WriteLine($"Creating NEW CarModel: {brand} {model} ({color})");
        }
        else
        {
            Console.WriteLine($"Reusing EXISTING CarModel: {brand} {model} ({color})");
        }

        return carModel;
    }

    public int GetModelsCount() => _cache.Count;
}

public class Car
{
    private readonly string _licensePlate;
    private readonly int _parkingSpot;
    private readonly CarModel _model;

    public Car(string licensePlate, int parkingSpot, CarModel model)
    {
        _licensePlate = licensePlate;
        _parkingSpot = parkingSpot;
        _model = model;
    }

    public void Print()
    {
        _model.ShowInfo(_licensePlate, _parkingSpot);
    }
}

public static class FlyweightDemo
{
    public static void Run()
    {
        var factory = new CarModelFactory();
        
        var bmwModel1 = factory.GetCarModel("BMW", "3 Series", "black");
        var bmwModel2 = factory.GetCarModel("BMW", "3 Series", "black");
        
        var golfModel = factory.GetCarModel("VW", "Golf", "red");
        
        var car1 = new Car("ABC 123", 1, bmwModel1);
        var car2 = new Car("DEF 456", 2, bmwModel2);
        var car3 = new Car("GHI 789", 3, golfModel);

        car1.Print();
        car2.Print();
        car3.Print();

        Console.WriteLine();
        Console.WriteLine($"bmwModel1 hash: {bmwModel1.GetHashCode()}");
        Console.WriteLine($"bmwModel2 hash: {bmwModel2.GetHashCode()}");
        Console.WriteLine($"Distinct CarModel objects in" +
                          $" factory: {factory.GetModelsCount()}");
    }
}
