namespace Krosoft.Extensions.Cqrs.Models;

public interface IAuthTenant
{
    string? CurrentTenantId { get; set; }

    bool IsTenantIdRequired => true;
}