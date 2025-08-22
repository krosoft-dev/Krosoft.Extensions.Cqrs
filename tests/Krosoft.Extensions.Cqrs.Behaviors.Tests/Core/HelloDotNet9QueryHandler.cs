using MediatR;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;

public class HelloDotNet9QueryHandler : IRequestHandler<HelloQuery, string>
{
    private readonly ILogger<HelloDotNet9QueryHandler> _logger;

    public HelloDotNet9QueryHandler(ILogger<HelloDotNet9QueryHandler> logger)
    {
        _logger = logger;
    }

    public Task<string> Handle(HelloQuery request,
                               CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hello World...");

        return Task.FromResult("Hello World !");
    }
}