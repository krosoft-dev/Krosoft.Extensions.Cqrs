using Krosoft.Extensions.Cqrs.Behaviors.Identity.PipelineBehaviors;
using Krosoft.Extensions.Cqrs.Models;
using Krosoft.Extensions.Identity.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Identity.Tests;

[TestClass]
public class AuthPipelineBehaviorTests
{
    private AuthPipelineBehavior<IAuthUser, object> _behavior = null!;
    private Mock<IIdentityService> _identityServiceMock = null!;
    private Mock<ILogger<AuthPipelineBehavior<IAuthUser, object>>> _loggerMock = null!;

    [TestInitialize]
    public void Setup()
    {
        _identityServiceMock = new Mock<IIdentityService>();
        _loggerMock = new Mock<ILogger<AuthPipelineBehavior<IAuthUser, object>>>();
        _behavior = new AuthPipelineBehavior<IAuthUser, object>(_loggerMock.Object, _identityServiceMock.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldSetUserId_WhenUserIdIsRequired()
    {
        var userId = "TestUserId";
        var authUserMock = new Mock<IAuthUser>(MockBehavior.Strict);
        authUserMock.Setup(x => x.IsUserIdRequired).Returns(true);
        authUserMock.SetupProperty(x => x.CurrentUserId);
        _identityServiceMock.Setup(x => x.GetId()).Returns(userId);

        await _behavior.Handle(authUserMock.Object, Next, CancellationToken.None);

        Check.That(authUserMock.Object.CurrentUserId).IsEqualTo(userId);
    }

    [TestMethod]
    public async Task Handle_ShouldNotSetUserId_WhenUserIdIsNotRequired()
    {
        var authUserMock = new Mock<IAuthUser>(MockBehavior.Strict);
        authUserMock.Setup(x => x.IsUserIdRequired).Returns(false);
        authUserMock.SetupProperty(x => x.CurrentUserId);

        await _behavior.Handle(authUserMock.Object, Next, CancellationToken.None);

        Check.That(authUserMock.Object.CurrentUserId).IsNull();
    }

    private Task<object> Next(CancellationToken t) => Task.FromResult((object?)null!);
}