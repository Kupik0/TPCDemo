
using TPCDemo.Application.Catalog.Hayvans;

namespace TPCDemo.Application.Catalog.Kedis;

public class KediDto : HayvanDto , IDto
{
    public Guid Id { get; set; }
    public string Ses { get; set; } = default!;
   
}