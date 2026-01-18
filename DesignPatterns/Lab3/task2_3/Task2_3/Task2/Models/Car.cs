namespace Task2.Models;

using Task2.Strategy;

public class Car
{
    public string Model { get; }
    public int Speed { get; private set; }

    public IDriveMode Mode { get; set; }

    public Car(string model, IDriveMode mode)
    {
        Model = model;
        Mode = mode;
        Speed = 0;
    }

    public void Accelerate(int requestedDelta)
    {
        int actualDelta = Mode.GetAccelerationDelta(requestedDelta);
        Speed += actualDelta;
        if (Speed < 0) Speed = 0;
    }

    public void Brake(int requestedDelta)
    {
        int actualDelta = Mode.GetBrakeDelta(requestedDelta);
        Speed -= actualDelta;
        if (Speed < 0) Speed = 0;
    }

    public override string ToString() => $"{Model} | Speed={Speed} | Mode={Mode.Name}";
}
