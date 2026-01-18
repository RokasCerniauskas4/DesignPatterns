namespace Task3;

public abstract class Car
{
    private string _model;
    private int _speed;

    public event EventHandler<CarPropertyChangedEventArgs>? PropertyChangedDetailed;

    public string Model
    {
        get => _model;
        set => SetField(ref _model, value, nameof(Model));
    }

    public int Speed
    {
        get => _speed;
        set => SetField(ref _speed, value, nameof(Speed));
    }

    protected Car(string model)
    {
        _model = model;
        _speed = 0;
    }

    public void Accelerate(int amount) => Speed += amount;
    public void Brake(int amount) => Speed = Math.Max(0, Speed - amount);

    protected bool SetField<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        var oldValue = field;
        field = value;

        PropertyChangedDetailed?.Invoke(this,
            new CarPropertyChangedEventArgs(propertyName, oldValue, value));

        return true;
    }

    public override string ToString() => $"{GetType().Name}({Model})";
}