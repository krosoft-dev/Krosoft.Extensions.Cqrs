namespace Krosoft.Extensions.Cqrs.Models;

public interface IAuthUser
{
    string? CurrentUserId { get; set; }

    bool IsUserIdRequired => true;
}