namespace Task2.Strategy;

public class SportMode : IDriveMode
{
    public string Name => "SPORT";

    public int GetAccelerationDelta(int requestedDelta) => requestedDelta * 2;
    public int GetBrakeDelta(int requestedDelta) => requestedDelta;
}