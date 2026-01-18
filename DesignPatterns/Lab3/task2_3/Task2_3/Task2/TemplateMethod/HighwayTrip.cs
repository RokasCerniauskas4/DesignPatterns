using Task2.Models;
using Task2.Strategy;

namespace Task2.TemplateMethod;

public class HighwayTrip : TripTemplate
{
    protected override void Prepare(Car car)
    {
        car.Mode = new SportMode();
    }

    protected override void Drive(Car car)
    {
        
        car.Accelerate(20);
        car.Accelerate(10);
        car.Brake(5);
    }

    protected override void Finish(Car car)
    {
        car.Brake(999);
    }
}
