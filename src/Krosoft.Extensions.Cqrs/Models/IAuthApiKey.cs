namespace Krosoft.Extensions.Cqrs.Models;

public interface IAuthApiKey
{
    bool IsApiKeyRequired => true;
    string? CurrentApiKey { get; set; }
}