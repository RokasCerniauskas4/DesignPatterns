namespace Task3;

public class Container
{
    private readonly List<Car> _cars = new();

    public void Add(Car car)
    {
        _cars.Add(car);

        Console.WriteLine($"Added: {car.GetType().Name}");
        
        car.PropertyChangedDetailed += OnCarPropertyChanged;
    }

    public void Remove(Car car)
    {
        if (_cars.Remove(car))
        {
            car.PropertyChangedDetailed -= OnCarPropertyChanged;
        }
    }

    private void OnCarPropertyChanged(object? sender, CarPropertyChangedEventArgs e)
    {
        if (sender is not Car car) return;

        Console.WriteLine($"{car.GetType().Name} '{car.Model}' changed {e.PropertyName}: {e.OldValue} -> {e.NewValue}");
    }
}