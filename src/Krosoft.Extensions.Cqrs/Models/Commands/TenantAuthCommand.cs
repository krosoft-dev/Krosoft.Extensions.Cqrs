namespace Krosoft.Extensions.Cqrs.Models.Commands;

public record TenantAuthCommand : AuthBaseCommand
{
    public override bool IsUserIdRequired => false;
}

public record TenantAuthCommand<T> : AuthBaseCommand<T>
{
    public override bool IsUserIdRequired => false;
}