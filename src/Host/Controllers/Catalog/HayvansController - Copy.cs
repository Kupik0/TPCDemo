using TPCDemo.Application.Catalog.Hayvans;

namespace TPCDemo.Host.Controllers.Catalog;

public class HayvansController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Hayvans)]
    [OpenApiOperation("Search brands using available filters.", "")]
    public Task<PaginationResponse<HayvanDto>> SearchAsync(SearchHayvansRequest request)
    {
        return Mediator.Send(request);
    }




}