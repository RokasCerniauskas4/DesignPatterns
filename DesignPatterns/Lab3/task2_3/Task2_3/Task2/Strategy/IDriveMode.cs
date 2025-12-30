namespace Task2.Strategy;

public interface IDriveMode
{
    string Name { get; }

    int GetAccelerationDelta(int requestedDelta);
    int GetBrakeDelta(int requestedDelta);
}