namespace TPCDemo.Domain.Catalog;

public class Kedi : Hayvan, IAggregateRoot
{
    public string Ses { get; set; }

    public Kedi(string ses,string name, string? description) : base(name, description)
    {
        Ses = ses;
        Name = name;
        Description = description;
    }

    public Kedi Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}