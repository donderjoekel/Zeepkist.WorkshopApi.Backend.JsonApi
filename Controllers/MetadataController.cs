using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Services;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.JsonApi.Controllers;

public class MetadataController : ReadOnlyController<Metadata, string>
{
    public MetadataController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<Metadata, string> resourceService
    )
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
