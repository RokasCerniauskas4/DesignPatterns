using System;
using System.Collections.Generic;

namespace Task2;

public class SmartCrudApiClient
{
    private readonly SomeEntityController _controller;
    private readonly CrudApiClient _crudClient;

    public SmartCrudApiClient(SomeEntityController controller)
    {
        _controller = controller;
        _crudClient = new CrudApiClient(controller);
    }
    
    public SomeEntity Create(string name, string description)
    {
        return _crudClient.Create(name, description);
    }
    
    public List<SomeEntity> GetActive()
    {
        return _controller.GetByFilter(e => e.Status == EntityStatus.Active);
    }
    
    public List<SomeEntity> GetInactive()
    {
        return _controller.GetByFilter(e => e.Status == EntityStatus.Inactive);
    }
    
    public List<SomeEntity> GetByName(string name)
    {
        return _controller.GetByFilter(
            e => e.Name != null && e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public List<SomeEntity> GetByNamePrefix(string prefix)
    {
        return _controller.GetByFilter(
            e => e.Name != null && e.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
    }
    
    public List<SomeEntity> Search(string text)
    {
        return _controller.GetByFilter(
            e =>
                (!string.IsNullOrEmpty(e.Name) &&
                 e.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                ||
                (!string.IsNullOrEmpty(e.Description) &&
                 e.Description.Contains(text, StringComparison.OrdinalIgnoreCase))
        );
    }
    

    public void PrintActive()
    {
        var active = GetActive();
        _controller.PrintMany(active);
    }

    public void PrintInactive()
    {
        var inactive = GetInactive();
        _controller.PrintMany(inactive);
    }

    public void PrintByNamePrefix(string prefix)
    {
        var items = GetByNamePrefix(prefix);
        _controller.PrintMany(items);
    }
}
