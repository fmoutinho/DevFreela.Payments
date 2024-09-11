using DevFreela.Payments.Domain.Abstractions;
using MediatR;

namespace DevFreela.Payments.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
