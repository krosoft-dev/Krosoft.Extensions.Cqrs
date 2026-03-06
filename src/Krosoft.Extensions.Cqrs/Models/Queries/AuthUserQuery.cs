namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record AuthUserQuery<TResponse> : AuthBaseQuery<TResponse> 
{
    public override bool IsTenantIdRequired => false;
}