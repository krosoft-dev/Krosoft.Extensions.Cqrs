using System.Diagnostics;
using Krosoft.Extensions.Core.Extensions;
using Krosoft.Extensions.Cqrs.Models;
using Krosoft.Extensions.Identity.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Identity.PipelineBehaviors;

public class AuthPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AuthPipelineBehavior<TRequest, TResponse>> _logger;

    public AuthPipelineBehavior(ILogger<AuthPipelineBehavior<TRequest, TResponse>> logger,
                                IIdentityService identityService)
    {
        _logger = logger;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request,
                                        RequestHandlerDelegate<TResponse> next,
                                        CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        _logger.LogInformation("Handling AuthPipelineBehavior <{TRequest},{TResponse}>", typeof(TRequest).Name, typeof(TResponse).Name);

        if (request is IAuthUser authUser && authUser.IsUserIdRequired)
        {
            authUser.CurrentUserId = _identityService.GetId();
        }

        if (request is IAuthTenant tenantContext && tenantContext.IsTenantIdRequired)
        {
            tenantContext.CurrentTenantId = _identityService.GetUniqueTenantId();
        }

        _logger.LogInformation("Handled AuthPipelineBehavior <{TRequest},{TResponse}> in {Elapsed}", typeof(TRequest).Name, typeof(TResponse).Name, sw.Elapsed.ToShortString());
        return await next();
    }
}