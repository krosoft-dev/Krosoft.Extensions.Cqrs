namespace Krosoft.Extensions.Cqrs.Models.Commands;

public interface IApiKeyCommand : ICommand, IApiKey;

public interface IApiKeyCommand<out T> : ICommand<T>, IApiKey;