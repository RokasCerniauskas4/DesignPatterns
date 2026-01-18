namespace Task1;

public sealed class Parallelepiped : IShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Parallelepiped(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Accept(IShapeVisitor visitor) => visitor.Visit(this);
}
