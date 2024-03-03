using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace TNRD.Zeepkist.WorkshopApi.Backend.JsonApi.Controllers;

public class ReadOnlyController<TResource> : JsonApiController<TResource, int>
    where TResource : class, IIdentifiable<int>
{
    public ReadOnlyController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<TResource, int> resourceService
    )
        : base(options,
            resourceGraph,
            loggerFactory,
            resourceService,
            resourceService,
            resourceService,
            resourceService)
    {
    }

    [HttpGet]
    public override Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        return base.GetAsync(cancellationToken);
    }

    [HttpGet("{id}")]
    public override Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        return base.GetAsync(id, cancellationToken);
    }

    [HttpGet("{id}/{relationshipName}")]
    public override Task<IActionResult> GetSecondaryAsync(
        int id,
        string relationshipName,
        CancellationToken cancellationToken
    )
    {
        return base.GetSecondaryAsync(id, relationshipName, cancellationToken);
    }

    [HttpGet("{id}/relationships/{relationshipName}")]
    public override Task<IActionResult> GetRelationshipAsync(
        int id,
        string relationshipName,
        CancellationToken cancellationToken
    )
    {
        return base.GetRelationshipAsync(id, relationshipName, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> DeleteRelationshipAsync(
        int id,
        string relationshipName,
        ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PatchAsync(int id, TResource resource, CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PatchRelationshipAsync(
        int id,
        string relationshipName,
        object? rightValue,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PostAsync(TResource resource, CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PostRelationshipAsync(
        int id,
        string relationshipName,
        ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }
}
