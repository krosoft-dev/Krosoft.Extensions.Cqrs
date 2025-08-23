namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record AuthBaseQuery<TResponse> : BaseQuery<TResponse>, IAuthQuery<TResponse>
{
    public virtual bool IsTenantIdRequired => true;
    public virtual bool IsUserIdRequired => true;
    public string? CurrentTenantId { get; set; }
    public string? CurrentUserId { get; set; }
}
 