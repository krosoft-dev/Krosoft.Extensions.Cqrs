using System.Reflection;
using Krosoft.Extensions.Cqrs.Behaviors.Extensions;
using Krosoft.Extensions.Cqrs.Behaviors.PipelineBehaviors;
using Krosoft.Extensions.Cqrs.Models.Queries;
using Krosoft.Extensions.Testing;
using Krosoft.Extensions.Testing.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests;

[TestClass]
public class ZipServiceTests : BaseTest
{
    private IMediator _mediator = null!;
    private Mock<ILogger<HelloDotNet9QueryHandler>> _mockLogger = null!;
    private Mock<ILogger<LoggingPipelineBehavior<HelloQuery, string>>> _mockLogger2 = null!;

    protected override void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        _mockLogger = new Mock<ILogger<HelloDotNet9QueryHandler>>();
        services.SwapTransient(_ => _mockLogger.Object);
        _mockLogger2 = new Mock<ILogger<LoggingPipelineBehavior<HelloQuery,string>>>();
        services.SwapTransient(_ => _mockLogger2.Object);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddBehaviors(options =>
        {
            options.AddLogging();
        });
    }

    [TestInitialize]
    public void SetUp()
    {
        var serviceProvider = CreateServiceCollection();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [TestMethod]
    public async Task ZipAsync_Ok()
    {
        var query = new HelloQuery();
        var message = await _mediator.Send(query, CancellationToken.None);

        Check.That(message).IsEqualTo("Hello World !");
    }
}

public record HelloQuery : BaseQuery<string>;

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