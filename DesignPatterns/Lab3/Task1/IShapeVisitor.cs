namespace Task1;

public interface IShapeVisitor
{
    double Visit(Sphere s);
    double Visit(Cube c);
    double Visit(Parallelepiped p);
    double Visit(Torus t);

}