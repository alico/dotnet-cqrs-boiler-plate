﻿using CQRS.Boilerplate.Application.Common.Exceptions;
using CQRS.Boilerplate.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CQRS.Boilerplate.Application.Common.Behaviours;
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;

        _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);
    }
}

