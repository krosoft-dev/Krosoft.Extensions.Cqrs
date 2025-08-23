namespace Krosoft.Extensions.Cqrs.Models;

public interface IApiKey
{
    bool IsApiKeyRequired => true;
    string? CurrentApiKey { get; set; }
}