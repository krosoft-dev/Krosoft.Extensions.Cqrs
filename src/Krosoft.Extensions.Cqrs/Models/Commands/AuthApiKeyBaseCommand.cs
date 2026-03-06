namespace Krosoft.Extensions.Cqrs.Models.Commands;

public abstract record AuthApiKeyBaseCommand : BaseCommand, IAuthApiKeyCommand
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}

public abstract record AuthApiKeyBaseCommand<T> : BaseCommand<T>, IAuthApiKeyCommand<T>
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}