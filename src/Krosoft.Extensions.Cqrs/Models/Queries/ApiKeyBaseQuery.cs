namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record ApiKeyBaseQuery<TResponse> : BaseQuery<TResponse>, IApiKeyQuery<TResponse>
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}
 