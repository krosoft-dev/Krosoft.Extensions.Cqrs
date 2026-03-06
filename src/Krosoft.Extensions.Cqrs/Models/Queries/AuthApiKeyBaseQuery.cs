namespace Krosoft.Extensions.Cqrs.Models.Queries;

public record AuthApiKeyBaseQuery<TResponse> : BaseQuery<TResponse>, IAuthApiKeyQuery<TResponse>
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}
 