using System.Collections.Generic;

namespace DesignPatterns
{
    public interface ICar
    {
        int Weight { get; set; }
        int Length { get; set; }
        int MaxSpeed { get; set; }
    }

    public class Vehicle : ICar
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int MaxSpeed { get; set; }
        public string WheelDrive { get; set; } = "front";
        public string Class { get; set; } = "sedan";
        public string Color { get; set; } = "black";
        public override string ToString() => $"Vehicle W={Weight} L={Length} V={MaxSpeed} {WheelDrive} {Class} {Color}";
    }

    public class Cargo : ICar
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int MaxSpeed { get; set; }
        public int Tonnage { get; set; }
        public int TankVolume { get; set; }
        public int AxlesAmount { get; set; }
        public override string ToString() => $"Cargo W={Weight} L={Length} V={MaxSpeed} T={Tonnage} TV={TankVolume} Ax={AxlesAmount}";
    }

    public class Tank : ICar
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int MaxSpeed { get; set; }
        public int ProjectileCaliber { get; set; }
        public int ShotsPerMinute { get; set; }
        public int CrewSize { get; set; }
        public override string ToString() => $"Tank W={Weight} L={Length} V={MaxSpeed} Cal={ProjectileCaliber} SPM={ShotsPerMinute} Crew={CrewSize}";
    }
    
    public static class CarFactory
    {
        public static ICar Create(string kind) => (kind ?? string.Empty).ToLowerInvariant() switch
        {
            "vehicle" => new Vehicle(),
            "cargo"   => new Cargo(),
            "tank"    => new Tank(),
            _         => new Vehicle()
        };
    }
    
    public interface ICarFactoryProd
    {
        Vehicle CreateVehicle();
        Cargo   CreateCargo();
        Tank    CreateTank();
    }
    
    public class ProductionFactory : ICarFactoryProd
    {
        public Vehicle CreateVehicle() => new() { WheelDrive = "front", Class = "hatchback", Color = "red" };
        public Cargo   CreateCargo()   => new() { AxlesAmount = 3, Tonnage = 12, TankVolume = 600 };
        public Tank    CreateTank()    => new() { ProjectileCaliber = 120, ShotsPerMinute = 8, CrewSize = 4 };
    }
    
    public static class CarBuilder
    {
        public static Vehicle BuildVehicle(int weight, int length, int maxSpeed, string wheelDrive, string @class, string color)
        {
            if (string.IsNullOrWhiteSpace(wheelDrive)) wheelDrive = "front";
            if (string.IsNullOrWhiteSpace(@class))     @class     = "sedan";
            if (string.IsNullOrWhiteSpace(color))      color      = "red";

            return new Vehicle
            {
                Weight     = weight,
                Length     = length,
                MaxSpeed   = maxSpeed,
                WheelDrive = wheelDrive,
                Class      = @class,
                Color      = color
            };
        }

        public static Cargo BuildCargo(int weight, int length, int maxSpeed, int tonnage, int tankVolume, int axles)
            => new() { Weight = weight, Length = length, MaxSpeed = maxSpeed, Tonnage = tonnage, TankVolume = tankVolume, AxlesAmount = axles };

        public static Tank BuildTank(int weight, int length, int maxSpeed, int caliber, int spm, int crew)
            => new() { Weight = weight, Length = length, MaxSpeed = maxSpeed, ProjectileCaliber = caliber, ShotsPerMinute = spm, CrewSize = crew };
    }
    
    public static class CarStore
    {
        static readonly List<ICar> items = new();
        public static T Add<T>(T car) where T : ICar { items.Add(car); return car; }
        public static IEnumerable<ICar> All() => items;
        public static bool RemoveAt(int i) { if (i < 0 || i >= items.Count) return false; items.RemoveAt(i); return true; }
    }
}
