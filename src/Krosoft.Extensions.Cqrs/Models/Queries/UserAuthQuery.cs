namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record UserAuthQuery<TResponse> : AuthBaseQuery<TResponse>
{
    public override bool IsTenantIdRequired => false;
}