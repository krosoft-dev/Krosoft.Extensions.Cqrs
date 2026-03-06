using System.Diagnostics;
using Krosoft.Extensions.Core.Extensions;
using Krosoft.Extensions.Cqrs.Models;
using Krosoft.Extensions.Identity.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Krosoft.Extensions.Cqrs.Behaviors.Identity.PipelineBehaviors;

public class AuthApiKeyPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IApiKeyProvider _apiKeyProvider;
    private readonly ILogger<AuthApiKeyPipelineBehavior<TRequest, TResponse>> _logger;

    public AuthApiKeyPipelineBehavior(ILogger<AuthApiKeyPipelineBehavior<TRequest, TResponse>> logger,
                                      IApiKeyProvider apiKeyProvider)
    {
        _logger = logger;
        _apiKeyProvider = apiKeyProvider;
    }

    public async Task<TResponse> Handle(TRequest request,
                                        RequestHandlerDelegate<TResponse> next,
                                        CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        _logger.LogInformation("Handling ApiKeyPipelineBehavior <{TRequest},{TResponse}>", typeof(TRequest).Name, typeof(TResponse).Name);

        if (request is IAuthApiKey authApiKey && authApiKey.IsApiKeyRequired)
        {
            authApiKey.CurrentApiKey = await _apiKeyProvider.GetApiKeyAsync(cancellationToken);
        }

        _logger.LogInformation("Handled ApiKeyPipelineBehavior <{TRequest},{TResponse}> in {Elapsed}", typeof(TRequest).Name, typeof(TResponse).Name, sw.Elapsed.ToShortString());
        return await next();
    }
}