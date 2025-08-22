using Krosoft.Extensions.Cqrs.Models.Queries;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;

internal record HelloSearchQuery : SearchPaginationRequestQuery<HelloDto>
{
    public string? Name { get; set; }          
}