namespace Krosoft.Extensions.Cqrs.Models.Commands;

public abstract record ApiKeyBaseCommand : BaseCommand, IApiKeyCommand
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}

public abstract record ApiKeyBaseCommand<T> : BaseCommand<T>, IApiKeyCommand<T>
{
    public virtual bool IsApiKeyRequired => true;
    public string? CurrentApiKey { get; set; } 
}