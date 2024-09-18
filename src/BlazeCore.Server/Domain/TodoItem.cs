namespace BlazeCore.Server.Domain;

public sealed class TodoItem
{
    private TodoItem(string id, string name, string description, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    public string Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }
    
    public void Update(string name, string description, DateTime createdAt)
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }
    
    public static TodoItem Create(string id, string name, string description, DateTime createdAt)
    {
        return new TodoItem(id, name, description, createdAt);
    }
}