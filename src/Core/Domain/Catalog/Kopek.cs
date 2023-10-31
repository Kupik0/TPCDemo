namespace TPCDemo.Domain.Catalog;

public class Kopek : Hayvan, IAggregateRoot
{
    public string Ses { get; set; }

    public Kopek(string name, string? description) : base(name, description)
    {
        Name = name;
        Description = description;
    }

    public Kopek Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}