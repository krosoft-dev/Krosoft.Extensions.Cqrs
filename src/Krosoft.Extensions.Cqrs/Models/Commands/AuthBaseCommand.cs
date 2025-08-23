namespace Krosoft.Extensions.Cqrs.Models.Commands;

public abstract record AuthBaseCommand : BaseCommand, IAuthCommand
{
    public virtual bool IsTenantIdRequired => true;
    public virtual bool IsUserIdRequired => true;
    public string? CurrentTenantId { get; set; }
    public string? CurrentUserId { get; set; }
}

public abstract record AuthBaseCommand<T> : BaseCommand<T>, IAuthCommand<T>
{
    public virtual bool IsTenantIdRequired => true;
    public virtual bool IsUserIdRequired => true;
    public string? CurrentTenantId { get; set; }
    public string? CurrentUserId { get; set; }
}