namespace Task2;

public class CrudApiClient
{
    private readonly SomeEntityController _controller;

    public CrudApiClient(SomeEntityController controller)
    {
        _controller = controller;
    }
    
    
    public SomeEntity Create(string name, string description)
    {
        var entity = new SomeEntity
        {
            Name = name,
            Description = description
        };

        return _controller.Create(entity);
    }
    
    public SomeEntity? GetOne(int id)
    {
        return _controller.GetOne(id);
    }

    public List<SomeEntity> GetMany()
    {
        return _controller.GetMany();
    }

    public void Update(int id, string name, string description, EntityStatus status)
    {
        var existing = _controller.GetOne(id);
        if (existing == null)
        {
            return;
        }

        existing.Name = name;
        existing.Description = description;
        existing.Status = status;

        _controller.Update(existing);
    }
    
    public void Delete(int id)
    {
        _controller.Delete(id);
    }
    
    public void DeleteMany(IEnumerable<int> ids)
    {
        _controller.DeleteMany(ids);
    }


    
}