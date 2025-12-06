using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Client;

internal class Program
{
    static void Main(string[] args)
    {
        using var httpClient = new HttpClient();
        const string baseUrl = "http://localhost:5122/";

        var crudClient = new CrudApiClient(httpClient, baseUrl);
        var smartClient = new SmartCrudApiClient(crudClient);

        var e1 = crudClient.Create("Whiskey A", "Smoky Islay whiskey");
        var e2 = crudClient.Create("Whiskey B", "Sweet Speyside whiskey");
        var e3 = crudClient.Create("Beer C", "Local IPA beer");

        crudClient.Update(e2.Id, e2.Name, e2.Description, EntityStatus.Inactive);

        Console.WriteLine("=== All entities (per CrudApiClient) ===");
        PrintMany(crudClient.GetMany());

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
        PrintMany(crudClient.GetMany());

        Console.WriteLine();
        Console.WriteLine("Done. Press Enter to exit...");
        Console.ReadLine();
    }

    private static void Print(SomeEntity entity)
        => Console.WriteLine($"[{entity.Id}] {entity.Name} ({entity.Status}) - {entity.Description}");

    private static void PrintMany(IEnumerable<SomeEntity> entities)
    {
        foreach (var e in entities) Print(e);
    }
}