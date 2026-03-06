namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record AuthTenantQuery<TResponse> : AuthBaseQuery<TResponse>
{
    public override bool IsUserIdRequired => false;
}