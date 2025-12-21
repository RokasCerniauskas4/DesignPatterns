namespace Task1;

public interface IShape
{
    
    double Accept(IShapeVisitor visitor);
    
}