using Task2.Models;
using Task2.Strategy;

namespace Task2.Command;

public class SetModeCommand : ICommand
{
    private readonly Car _car;
    private readonly IDriveMode _mode;

    public string Name => $"SetMode({_mode.Name})";

    public SetModeCommand(Car car, IDriveMode mode)
    {
        _car = car;
        _mode = mode;
    }

    public void Execute() => _car.Mode = _mode;
}
