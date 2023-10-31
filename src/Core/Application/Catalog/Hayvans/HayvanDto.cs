namespace TPCDemo.Application.Catalog.Hayvans;

public class HayvanDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

}