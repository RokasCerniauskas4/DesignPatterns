using Task1;

var shapes = new IShape[]
{
    new Sphere(3),
    new Cube(4),
    new Parallelepiped(2, 3, 4),
    new Torus(5, 2)
};

var vv = new VolumeVisitor();

foreach (var sh in shapes)
{
    Console.WriteLine($"{sh.GetType().Name}: {sh.Accept(vv)}");
}