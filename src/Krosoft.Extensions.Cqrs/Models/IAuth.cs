namespace Krosoft.Extensions.Cqrs.Models;

public interface IAuth
{
    string? CurrentUserId { get; set; }
    string? CurrentTenantId { get; set; }

    bool IsUserIdRequired => true;
    bool IsTenantIdRequired => true;
}