namespace Krosoft.Extensions.Cqrs.Models.Commands;

public record UserAuthCommand : AuthBaseCommand
{
    public override bool IsTenantIdRequired => false;
}

public record UserAuthCommand<T> : AuthBaseCommand<T>
{
    public override bool IsTenantIdRequired => false;
}