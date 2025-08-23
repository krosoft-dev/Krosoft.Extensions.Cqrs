﻿using System.Diagnostics;
using Krosoft.Extensions.Core.Extensions;
using Krosoft.Extensions.Core.Models.Exceptions;
using Krosoft.Extensions.Cqrs.Models;
using Krosoft.Extensions.Cqrs.Models.Commands;
using Krosoft.Extensions.Cqrs.Models.Queries;
using Krosoft.Extensions.Identity.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Identity.PipelineBehaviors;

public class AuthorizationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AuthorizationPipelineBehavior<TRequest, TResponse>> _logger;

    public AuthorizationPipelineBehavior(ILogger<AuthorizationPipelineBehavior<TRequest, TResponse>> logger,
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
        _logger.LogInformation("Handling AuthorizationPipelineBehavior <{TRequest},{TResponse}>", typeof(TRequest).Name, typeof(TResponse).Name);

        switch (request)
        {
            case IAuth auth:
                if (auth.IsUserIdRequired)
                {
                    auth.CurrentUserId = _identityService.GetId();
                }

                if (auth.IsTenantIdRequired)
                {
                    auth.CurrentTenantId = _identityService.GetUniqueTenantId();
                }

                break;

            case IQuery<TResponse>:
            case ICommand<TResponse>:
            case ICommand:
                break;

            default:
                throw new KrosoftTechnicalException($"Le type {typeof(TRequest)} n'est pas pris en compte pour cet appel.");
        }

        _logger.LogInformation("Handled AuthorizationPipelineBehavior <{TRequest},{TResponse}> in {Elapsed}", typeof(TRequest).Name, typeof(TResponse).Name, sw.Elapsed.ToShortString());
        return await next();
    }
}