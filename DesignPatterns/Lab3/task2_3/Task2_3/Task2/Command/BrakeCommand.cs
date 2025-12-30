using Task2.Models;

namespace Task2.Command;

public class BrakeCommand : ICommand
{
    private readonly Car _car;
    private readonly int _delta;

    public string Name => $"Brake({_delta})";

    public BrakeCommand(Car car, int delta)
    {
        _car = car;
        _delta = delta;
    }

    public void Execute() => _car.Brake(_delta);
}