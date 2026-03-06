namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record TenantAuthQuery<TResponse> : AuthBaseQuery<TResponse>
{
    public override bool IsUserIdRequired => false;
}