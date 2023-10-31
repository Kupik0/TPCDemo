namespace TPCDemo.Domain.Catalog;

public class Hayvan : AuditableEntity, IAggregateRoot
{
    public string Name { get;  set; }
    public string? Description { get;  set; }

    public Hayvan(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public Hayvan Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}