using System;
using System.Collections.Generic;
using System.Linq;

namespace Server;

public class SomeEntityController
{
    private readonly List<SomeEntity> _storage = new();
    private int _nextId = 1;

    public SomeEntity Create(SomeEntity entity)
    {
        int id = _nextId++;
        entity.Id = id;
        _storage.Add(entity);
        return entity;
    }

    public SomeEntity? GetOne(int id)
    {
        return _storage.FirstOrDefault(x => x.Id == id);
    }

    public List<SomeEntity> GetMany()
    {
        return _storage.ToList();
    }

    public List<SomeEntity> GetByFilter(Func<SomeEntity, bool> predicate)
    {
        return _storage.Where(predicate).ToList();
    }

    public void Update(SomeEntity updated)
    {
        var existing = GetOne(updated.Id);
        if (existing == null) return;

        existing.Name = updated.Name;
        existing.Description = updated.Description;
        existing.Status = updated.Status;
    }

    public void Delete(int id)
    {
        var entity = GetOne(id);
        if (entity == null) return;
        _storage.Remove(entity);
    }

    public void DeleteMany(IEnumerable<int> ids)
    {
        foreach (var id in ids)
            Delete(id);
    }

    public void SetStatus(int id, EntityStatus status)
    {
        var entity = GetOne(id);
        if (entity == null) return;
        entity.Status = status;
    }

    public void Activate(int id) => SetStatus(id, EntityStatus.Active);
    public void Deactivate(int id) => SetStatus(id, EntityStatus.Inactive);
}