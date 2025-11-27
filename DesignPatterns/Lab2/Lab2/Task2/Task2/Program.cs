namespace Task2;

internal class Program
{
    static void Main(string[] args)
    {
        var controller = new SomeEntityController();
        
        var crudClient = new CrudApiClient(controller);
        
        var smartClient = new SmartCrudApiClient(controller);

        var e1 = crudClient.Create("Whiskey A", "Smoky Islay whiskey");
        var e2 = crudClient.Create("Whiskey B", "Sweet Speyside whiskey");
        var e3 = crudClient.Create("Beer C", "Local IPA beer");
        
        crudClient.Update(e2.Id, e2.Name, e2.Description, EntityStatus.Inactive);

        Console.WriteLine("=== All entities (per controller) ===");
        controller.PrintMany(controller.GetMany());

        Console.WriteLine();
        Console.WriteLine("=== Active entities (per SmartCrudApiClient) ===");
        smartClient.PrintActive();

        Console.WriteLine();
        Console.WriteLine("=== Inactive entities (per SmartCrudApiClient) ===");
        smartClient.PrintInactive();

        Console.WriteLine();
        Console.WriteLine("=== Name starts with 'Whiskey' (per SmartCrudApiClient) ===");
        smartClient.PrintByNamePrefix("Whiskey");

        Console.WriteLine();
        Console.WriteLine("=== Delete first entity (per CrudApiClient) ===");
        crudClient.Delete(e1.Id);
        controller.PrintMany(controller.GetMany());

        Console.WriteLine();
        Console.WriteLine("Done. Press Enter to exit...");
        Console.ReadLine();
    }
}