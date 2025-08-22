using System.Reflection;
using Krosoft.Extensions.Cqrs.Behaviors.Extensions;
using Krosoft.Extensions.Cqrs.Behaviors.PipelineBehaviors;
using Krosoft.Extensions.Cqrs.Behaviors.Tests.Core;
using Krosoft.Extensions.Testing;
using Krosoft.Extensions.Testing.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Tests;

[TestClass]
public class MediatorTests : BaseTest
{
    private IMediator _mediator = null!;
    private Mock<ILogger<LoggingPipelineBehavior<HelloQuery, string>>> _mockLoggerBehavior = null!;
    private Mock<ILogger<HelloDotNet9QueryHandler>> _mockLoggerHandler = null!;

    protected override void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        _mockLoggerHandler = new Mock<ILogger<HelloDotNet9QueryHandler>>();
        _mockLoggerBehavior = new Mock<ILogger<LoggingPipelineBehavior<HelloQuery, string>>>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
                .AddBehaviors(options => { options.AddLogging(); })
                .SwapTransient(_ => _mockLoggerHandler.Object)
                .SwapTransient(_ => _mockLoggerBehavior.Object);
    }

    [TestInitialize]
    public void SetUp()
    {
        var serviceProvider = CreateServiceCollection();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [TestMethod]
    public async Task Send_Ok()
    {
        var query = new HelloQuery();
        var message = await _mediator.Send(query, CancellationToken.None);

        Check.That(message).IsEqualTo("Hello World !");
    }
}