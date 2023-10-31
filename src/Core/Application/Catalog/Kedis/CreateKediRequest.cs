using TPCDemo.Application.Catalog.Hayvans;

namespace TPCDemo.Application.Catalog.Kedis;

public class CreateKediRequest : HayvanDto,  IRequest<Guid>
{
    public string Ses { get; set; } = default!;
  }



public class CreateKediRequestHandler : IRequestHandler<CreateKediRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Kedi> _repository;

    public CreateKediRequestHandler(IRepositoryWithEvents<Kedi> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateKediRequest request, CancellationToken cancellationToken)
    {
        var brand = new Kedi(request.Ses,request.Name, request.Description);

        await _repository.AddAsync(brand, cancellationToken);

        return brand.Id;
    }
}