using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace TNRD.Zeepkist.WorkshopApi.Backend.JsonApi.Controllers;

public class ReadOnlyController<TResource, TId> : JsonApiController<TResource, TId>
    where TResource : class, IIdentifiable<TId>
{
    public ReadOnlyController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<TResource, TId> resourceService
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
    public override Task<IActionResult> GetAsync(TId id, CancellationToken cancellationToken)
    {
        return base.GetAsync(id, cancellationToken);
    }

    [HttpGet("{id}/{relationshipName}")]
    public override Task<IActionResult> GetSecondaryAsync(
        TId id,
        string relationshipName,
        CancellationToken cancellationToken
    )
    {
        return base.GetSecondaryAsync(id, relationshipName, cancellationToken);
    }

    [HttpGet("{id}/relationships/{relationshipName}")]
    public override Task<IActionResult> GetRelationshipAsync(
        TId id,
        string relationshipName,
        CancellationToken cancellationToken
    )
    {
        return base.GetRelationshipAsync(id, relationshipName, cancellationToken);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> DeleteRelationshipAsync(
        TId id,
        string relationshipName,
        ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PatchAsync(TId id, TResource resource, CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<IActionResult> PatchRelationshipAsync(
        TId id,
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
        TId id,
        string relationshipName,
        ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult<IActionResult>(new ForbidResult());
    }
}
