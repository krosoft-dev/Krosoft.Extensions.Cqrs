namespace Krosoft.Extensions.Cqrs.Models.Commands;

public interface IAuthApiKeyCommand : ICommand, IAuthApiKey;

public interface IAuthApiKeyCommand<out T> : ICommand<T>, IAuthApiKey;