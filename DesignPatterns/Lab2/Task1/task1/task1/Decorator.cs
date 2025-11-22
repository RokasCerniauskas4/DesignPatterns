namespace task1;


public interface IMessage
{
    string GetText();
}

public class SimpleMessage : IMessage
{
    private readonly string _text;

    public SimpleMessage(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }
}

public abstract class MessageDecorator : IMessage
{
    protected readonly IMessage inner;

    protected MessageDecorator(IMessage inner)
    {
        this.inner = inner;
    }

    public abstract string GetText();
}

public class UppercaseMessageDecorator : MessageDecorator
{
    public UppercaseMessageDecorator(IMessage inner) : base(inner)
    {
    }

    public override string GetText()
    {
        var original = inner.GetText();
        return original.ToUpper();
    }
}

public class PrefixMessageDecorator : MessageDecorator
{
    private readonly string _prefix;

    public PrefixMessageDecorator(IMessage inner, string prefix) : base(inner)
    {
        _prefix = prefix;
    }

    public override string GetText()
    {
        var original = inner.GetText();
        return _prefix + original;
    }
}

public static class DecoratorDemo
{
    public static void Run()
    {
        IMessage message = new SimpleMessage("hello world");

        Console.WriteLine("Original:");
        Console.WriteLine(message.GetText());
        
        IMessage upper = new UppercaseMessageDecorator(message);
        Console.WriteLine("Uppercase:");
        Console.WriteLine(upper.GetText());
        
        IMessage prefixed = new PrefixMessageDecorator(upper, "[INFO] ");
        Console.WriteLine("With prefix + uppercase:");
        Console.WriteLine(prefixed.GetText());
    }
}
