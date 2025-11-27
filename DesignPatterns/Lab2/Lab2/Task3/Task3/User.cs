public class User
{
    public string Name { get; }
    public bool IsRegistered { get; }
    public List<int> AllowedBookIds { get; }

    public User(string name, bool isRegistered, List<int> allowedBookIds)
    {
        Name = name;
        IsRegistered = isRegistered;
        AllowedBookIds = allowedBookIds;
    }

    public bool CanRead(int bookId)
    {
        return AllowedBookIds.Contains(bookId);
    }
}
