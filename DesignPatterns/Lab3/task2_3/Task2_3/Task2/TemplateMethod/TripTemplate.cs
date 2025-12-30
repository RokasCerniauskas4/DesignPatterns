using Task2.Models;

namespace Task2.TemplateMethod;

public abstract class TripTemplate
{
    public void Run(Car car)
    {
        Prepare(car);
        Drive(car);
        Finish(car);
    }

    protected virtual void Prepare(Car car) { }
    protected abstract void Drive(Car car);
    protected virtual void Finish(Car car) { }
}