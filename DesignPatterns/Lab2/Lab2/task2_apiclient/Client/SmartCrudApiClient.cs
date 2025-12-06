using System;
using System.Collections.Generic;
using System.Linq;

namespace Client;

public class SmartCrudApiClient
{
    private readonly CrudApiClient _crudClient;

    public SmartCrudApiClient(CrudApiClient crudClient)
    {
        _crudClient = crudClient;
    }

    private List<SomeEntity> GetAll() => _crudClient.GetMany();

    public SomeEntity Create(string name, string description)
        => _crudClient.Create(name, description);

    public List<SomeEntity> GetActive()
        => GetAll().Where(e => e.Status == EntityStatus.Active).ToList();

    public List<SomeEntity> GetInactive()
        => GetAll().Where(e => e.Status == EntityStatus.Inactive).ToList();

    public List<SomeEntity> GetByName(string name)
        => GetAll()
            .Where(e => !string.IsNullOrEmpty(e.Name) &&
                        e.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public List<SomeEntity> GetByNamePrefix(string prefix)
        => GetAll()
            .Where(e => !string.IsNullOrEmpty(e.Name) &&
                        e.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public List<SomeEntity> Search(string text)
        => GetAll()
            .Where(e =>
                (!string.IsNullOrEmpty(e.Name) &&
                 e.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                ||
                (!string.IsNullOrEmpty(e.Description) &&
                 e.Description.Contains(text, StringComparison.OrdinalIgnoreCase)))
            .ToList();

    public void PrintActive() => PrintMany(GetActive());
    public void PrintInactive() => PrintMany(GetInactive());
    public void PrintByNamePrefix(string prefix) => PrintMany(GetByNamePrefix(prefix));

    private void Print(SomeEntity e)
        => Console.WriteLine($"[{e.Id}] {e.Name} ({e.Status}) - {e.Description}");

    private void PrintMany(IEnumerable<SomeEntity> entities)
    {
        foreach (var e in entities) Print(e);
    }
}
