namespace DesignPatterns;

public class Watermelon
{
    public string Color { get; set; } = "green";
    public int Weight { get; set; }
    public bool Sweet { get; set; } = true;

    public Watermelon Clone() => (Watermelon)this.MemberwiseClone();

    public override string ToString() => $"{Color} Watermelon (Weight: {Weight} kg, Sweet? : {Sweet})";
}