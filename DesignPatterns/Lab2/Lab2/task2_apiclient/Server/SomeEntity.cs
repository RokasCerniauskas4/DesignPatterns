namespace Server;

public enum EntityStatus
{
    Active,
    Inactive
}

public class SomeEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public EntityStatus Status { get; set; } = EntityStatus.Active;
}