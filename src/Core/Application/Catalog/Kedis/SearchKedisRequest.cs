namespace TPCDemo.Application.Catalog.Kedis;

public class SearchKedisRequest : PaginationFilter, IRequest<PaginationResponse<KediDto>>
{
}

public class KedisBySearchRequestSpec : EntitiesByPaginationFilterSpec<Kedi, KediDto>
{
    public KedisBySearchRequestSpec(SearchKedisRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchKedisRequestHandler : IRequestHandler<SearchKedisRequest, PaginationResponse<KediDto>>
{
    private readonly IReadRepository<Kedi> _repository;

    public SearchKedisRequestHandler(IReadRepository<Kedi> repository) => _repository = repository;

    public async Task<PaginationResponse<KediDto>> Handle(SearchKedisRequest request, CancellationToken cancellationToken)
    {
        var spec = new KedisBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}