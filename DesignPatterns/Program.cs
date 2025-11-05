using DesignPatterns;

var veggie_drink = DrinkFactory.Create("veggie");
var fruit_drink = DrinkFactory.Create("fruit");
var energy_drink = DrinkFactory.Create("energy");

Console.WriteLine(veggie_drink.Name); veggie_drink.Make();
Console.WriteLine(fruit_drink.Name); fruit_drink.Make();
Console.WriteLine(energy_drink.Name); energy_drink.Make();

var factory = DrinkFactories.DecideYourDestiny("healthy");
var drink   = factory.CreateDrink("veggie");

Console.WriteLine(drink.Name);
drink.Make();

var pizza1 = PizzaBuilder.Build(false, false, false, false);
var pizza2 = PizzaBuilder.Build(false, true, false, true);
Console.WriteLine(pizza2.Name);

var baseWatermelon = new Watermelon { Color = "Red", Weight = 3 };
var yellowWatermelon = baseWatermelon.Clone();
yellowWatermelon.Color = "Yellow";
var heavyWatermelon = baseWatermelon.Clone();
heavyWatermelon.Weight = 10;
Console.WriteLine(heavyWatermelon);
Console.WriteLine(baseWatermelon);
Console.WriteLine(yellowWatermelon);

var a = Singleton.Instance;
var b = Singleton.Instance;

a.add_number();
b.add_number();

Console.WriteLine(a.Value);
Console.WriteLine(b.Value);
Console.WriteLine(object.ReferenceEquals(a, b));

var v1 = CarBuilder.BuildVehicle(1200, 4300, 200, "", "", "");
CarStore.Add(v1);

var productionPlant = new ProductionFactory();
var t1 = productionPlant.CreateTank();
t1.Weight = 60000; t1.Length = 7000; t1.MaxSpeed = 65;
CarStore.Add(t1);

var c1 = CarBuilder.BuildCargo(5000, 7500, 110, 12, 600, 3);
CarStore.Add(c1);

foreach (var car in CarStore.All()) Console.WriteLine(car);

Console.WriteLine(CarStore.RemoveAt(1));

int count = 0; foreach (var x in CarStore.All()) count++;
Console.WriteLine(count);
