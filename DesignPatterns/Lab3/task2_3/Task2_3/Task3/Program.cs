namespace Task3;

internal static class Program
{
    static void Main()
    {
        var container = new Container();

        var bmw = new SportsCar("BMW M3");
        var volvo = new Truck("Volvo FH");

        container.Add(bmw);
        container.Add(volvo);
        
        bmw.Speed = 20;
        bmw.Accelerate(15);
        bmw.NitroEnabled = true;

        volvo.LoadKg = 1200;
        volvo.Speed = 10;
        volvo.Brake(3);
        volvo.Model = "Volvo FH16";

        Console.WriteLine("Done.");
    }
}