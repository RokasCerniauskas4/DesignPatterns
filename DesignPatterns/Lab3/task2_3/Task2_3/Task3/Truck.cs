namespace Task3;

public class Truck : Car
{
    private int _loadKg;

    public int LoadKg
    {
        get => _loadKg;
        set => SetField(ref _loadKg, value, nameof(LoadKg));
    }

    public Truck(string model) : base(model) { }
}
