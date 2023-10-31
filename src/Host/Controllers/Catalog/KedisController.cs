using TPCDemo.Application.Catalog.Kedis;

namespace TPCDemo.Host.Controllers.Catalog;

public class KedisController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Kedis)]
    [OpenApiOperation("Search brands using available filters.", "")]
    public Task<PaginationResponse<KediDto>> SearchAsync(SearchKedisRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Kedis)]
    [OpenApiOperation("Create a new brand.", "")]
    public Task<Guid> CreateAsync(CreateKediRequest request)
    {
        return Mediator.Send(request);
    }

}