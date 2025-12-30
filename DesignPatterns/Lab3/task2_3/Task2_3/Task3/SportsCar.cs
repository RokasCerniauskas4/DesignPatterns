namespace Task3;

public class SportsCar : Car
{
    private bool _nitroEnabled;

    public bool NitroEnabled
    {
        get => _nitroEnabled;
        set => SetField(ref _nitroEnabled, value, nameof(NitroEnabled));
    }

    public SportsCar(string model) : base(model) { }
}
