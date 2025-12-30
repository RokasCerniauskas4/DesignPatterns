namespace Task3;

public sealed class CarPropertyChangedEventArgs : EventArgs
{
    public string PropertyName { get; }
    public object? OldValue { get; }
    public object? NewValue { get; }

    public CarPropertyChangedEventArgs(string propertyName, object? oldValue, object? newValue)
    {
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
    }
}