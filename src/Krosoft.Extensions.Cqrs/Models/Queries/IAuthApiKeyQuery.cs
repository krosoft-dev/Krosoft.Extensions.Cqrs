namespace Krosoft.Extensions.Cqrs.Models.Queries;

public interface IAuthApiKeyQuery<out TResponse> : IQuery<TResponse>, IAuthApiKey;