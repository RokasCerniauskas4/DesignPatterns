namespace Task1;

public sealed class Torus : IShape
{
    public double BigRadius { get; }
    public double SmallRadius { get; }

    public Torus(double BigRadius, double SmallRadius)
    {
        this.BigRadius = BigRadius;
        this.SmallRadius = SmallRadius;
    }

    public double Accept(IShapeVisitor visitor) => visitor.Visit(this);
}
