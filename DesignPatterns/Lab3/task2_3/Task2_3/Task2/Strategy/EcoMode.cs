namespace Task2.Strategy;

public class EcoMode : IDriveMode
{
    public string Name => "ECO";

    public int GetAccelerationDelta(int requestedDelta) => Math.Max(1, requestedDelta / 2);
    public int GetBrakeDelta(int requestedDelta) => requestedDelta;
}