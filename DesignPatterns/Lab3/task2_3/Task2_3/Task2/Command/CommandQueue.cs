namespace Task2.Command;

public class CommandQueue
{
    private readonly List<ICommand> _commands = new();

    public void Add(ICommand command) => _commands.Add(command);

    public void RunAll(Action<string>? logger = null)
    {
        foreach (var cmd in _commands)
        {
            logger?.Invoke(cmd.Name);
            cmd.Execute();
        }
        _commands.Clear();
    }
}