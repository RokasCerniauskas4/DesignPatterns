namespace Task1;

public sealed class Sphere : IShape
{
    public double Radius { get; }

    public Sphere(double radius)
    {
        Radius = radius;
    }

    public double Accept(IShapeVisitor visitor) => visitor.Visit(this);

}