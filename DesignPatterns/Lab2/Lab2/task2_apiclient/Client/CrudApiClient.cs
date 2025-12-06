using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace Client;

public class CrudApiClient
{
    private readonly HttpClient _httpClient;

    public CrudApiClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public SomeEntity Create(string name, string description)
    {
        var entity = new SomeEntity { Name = name, Description = description };

        var resp = _httpClient.PostAsJsonAsync("api/entities", entity).Result;
        resp.EnsureSuccessStatusCode();

        var created = resp.Content.ReadFromJsonAsync<SomeEntity>().Result;
        if (created == null)
            throw new InvalidOperationException("Empty response on Create");

        return created;
    }

    public SomeEntity? GetOne(int id)
    {
        var resp = _httpClient.GetAsync($"api/entities/{id}").Result;

        if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        resp.EnsureSuccessStatusCode();
        return resp.Content.ReadFromJsonAsync<SomeEntity>().Result;
    }

    public List<SomeEntity> GetMany()
    {
        var result = _httpClient.GetFromJsonAsync<List<SomeEntity>>("api/entities").Result;
        return result ?? new List<SomeEntity>();
    }

    public void Update(int id, string name, string description, EntityStatus status)
    {
        var entity = new SomeEntity
        {
            Id = id,
            Name = name,
            Description = description,
            Status = status
        };

        var resp = _httpClient.PutAsJsonAsync($"api/entities/{id}", entity).Result;
        resp.EnsureSuccessStatusCode();
    }

    public void Delete(int id)
    {
        var resp = _httpClient.DeleteAsync($"api/entities/{id}").Result;
        resp.EnsureSuccessStatusCode();
    }

    public void DeleteMany(IEnumerable<int> ids)
    {
        foreach (var id in ids)
            Delete(id);
    }
}
