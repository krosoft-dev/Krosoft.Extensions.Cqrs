namespace Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;

internal record HelloDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; } 
}