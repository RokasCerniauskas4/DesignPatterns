namespace Task1;

public sealed class Cube : IShape
{
    public double Side { get; }

    public Cube(double side)
    {
        Side = side;
    }

    public double Accept(IShapeVisitor visitor) => visitor.Visit(this);
}
