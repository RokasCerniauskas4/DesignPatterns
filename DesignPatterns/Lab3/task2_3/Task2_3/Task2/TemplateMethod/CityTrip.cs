using Task2.Models;
using Task2.Strategy;

namespace Task2.TemplateMethod;

public class CityTrip : TripTemplate
{
    protected override void Prepare(Car car)
    {
        car.Mode = new EcoMode();
    }

    protected override void Drive(Car car)
    {
        car.Accelerate(10);
        car.Brake(3);
        car.Accelerate(8);
        car.Brake(4);
        car.Accelerate(6);
    }

    protected override void Finish(Car car)
    {
        car.Brake(999);
    }
}