using Krosoft.Extensions.Cqrs.Behaviors.Identity.PipelineBehaviors;
using Krosoft.Extensions.Cqrs.Models;
using Krosoft.Extensions.Identity.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Identity.Tests;

[TestClass]
public class AuthApiKeyPipelineBehaviorTests
{
    private Mock<IApiKeyProvider> _apiKeyProviderMock = null!;
    private AuthApiKeyPipelineBehavior<IAuthApiKey, object> _behavior = null!;
    private Mock<ILogger<AuthApiKeyPipelineBehavior<IAuthApiKey, object>>> _loggerMock = null!;

    [TestInitialize]
    public void Setup()
    {
        _apiKeyProviderMock = new Mock<IApiKeyProvider>();
        _loggerMock = new Mock<ILogger<AuthApiKeyPipelineBehavior<IAuthApiKey, object>>>();
        _behavior = new AuthApiKeyPipelineBehavior<IAuthApiKey, object>(_loggerMock.Object, _apiKeyProviderMock.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldSetApiKey_WhenApiKeyIsRequired()
    {
        var apiKey = "TestApiKey";
        var authApiKeyMock = new Mock<IAuthApiKey>(MockBehavior.Strict);
        authApiKeyMock.Setup(x => x.IsApiKeyRequired).Returns(true);
        authApiKeyMock.SetupProperty(x => x.CurrentApiKey);
        _apiKeyProviderMock.Setup(x => x.GetApiKeyAsync(It.IsAny<CancellationToken>())).ReturnsAsync(apiKey);

        await _behavior.Handle(authApiKeyMock.Object, Next, CancellationToken.None);

        Check.That(authApiKeyMock.Object.CurrentApiKey).IsEqualTo(apiKey);
    }

    [TestMethod]
    public async Task Handle_ShouldNotSetApiKey_WhenApiKeyIsNotRequired()
    {
        var authApiKeyMock = new Mock<IAuthApiKey>(MockBehavior.Strict);
        authApiKeyMock.Setup(x => x.IsApiKeyRequired).Returns(false);
        authApiKeyMock.SetupProperty(x => x.CurrentApiKey);

        await _behavior.Handle(authApiKeyMock.Object, Next, CancellationToken.None);

        Check.That(authApiKeyMock.Object.CurrentApiKey).IsNull();
    }

    private static Task<object> Next(CancellationToken cancellationToken) => Task.FromResult((object?)null!);
}