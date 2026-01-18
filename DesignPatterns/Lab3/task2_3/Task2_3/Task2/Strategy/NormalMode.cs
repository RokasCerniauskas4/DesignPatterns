namespace Task2.Strategy;

public class NormalMode : IDriveMode
{
    public string Name => "NORMAL";

    public int GetAccelerationDelta(int requestedDelta) => requestedDelta;
    public int GetBrakeDelta(int requestedDelta) => requestedDelta;
}