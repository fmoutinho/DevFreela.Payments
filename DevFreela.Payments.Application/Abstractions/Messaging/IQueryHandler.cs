﻿using DevFreela.Payments.Domain.Abstractions;
using MediatR;

namespace DevFreela.Payments.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
