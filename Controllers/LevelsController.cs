using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Services;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.JsonApi.Controllers;

public class LevelsController : ReadOnlyController<Level>
{
    public LevelsController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<Level, int> resourceService
    )
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
