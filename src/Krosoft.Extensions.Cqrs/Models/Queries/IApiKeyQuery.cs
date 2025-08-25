namespace Krosoft.Extensions.Cqrs.Models.Queries;

public interface IApiKeyQuery<out TResponse> : IQuery<TResponse>, IApiKey;