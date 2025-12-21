namespace Task1;

public class VolumeVisitor : IShapeVisitor
{
    
    public double Visit(Sphere s)
    {
        return 4.0/3.0 * Math.PI * Math.Pow(s.Radius, 3);
    }
    public double Visit(Cube c)
    {
        return Math.Pow(c.Side, 3);
    }

    public double Visit(Parallelepiped p)
    {
        return p.A * p.B * p.C;
    }

    public double Visit(Torus t)
    {
        return 2 * Math.PI * Math.PI * t.BigRadius * Math.Pow(t.SmallRadius, 2);
    }
    
}