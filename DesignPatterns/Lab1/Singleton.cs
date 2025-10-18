namespace DesignPatterns;

public class Singleton
{
    private Singleton() { }
    public static readonly Singleton Instance = new();
    
    public int Value { get; private set; }
    public void add_number() => Value ++;
    
}
