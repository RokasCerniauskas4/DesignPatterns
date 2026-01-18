using Task2.Models;

namespace Task2.Command;

public class AccelerateCommand : ICommand
{
    private readonly Car _car;
    private readonly int _delta;

    public string Name => $"Accelerate({_delta})";

    public AccelerateCommand(Car car, int delta)
    {
        _car = car;
        _delta = delta;
    }

    public void Execute() => _car.Accelerate(_delta);
}