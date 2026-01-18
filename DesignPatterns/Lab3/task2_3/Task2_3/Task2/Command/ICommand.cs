namespace Task2.Command;

public interface ICommand
{
    string Name { get; }
    void Execute();
}
