namespace TPCDemo.Application.Catalog.Hayvans;

public class SearchHayvansRequest : PaginationFilter, IRequest<PaginationResponse<HayvanDto>>
{
}

public class HayvansBySearchRequestSpec : EntitiesByPaginationFilterSpec<Hayvan, HayvanDto>
{
    public HayvansBySearchRequestSpec(SearchHayvansRequest request) 
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchHayvansRequestHandler : IRequestHandler<SearchHayvansRequest, PaginationResponse<HayvanDto>>
{
    private readonly IReadRepository<Hayvan> _repository;

    public SearchHayvansRequestHandler(IReadRepository<Hayvan> repository) => _repository = repository;

    public async Task<PaginationResponse<HayvanDto>> Handle(SearchHayvansRequest request, CancellationToken cancellationToken)
    {
        var spec = new HayvansBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}