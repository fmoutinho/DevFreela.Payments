using DevFreela.Payments.Application.Abstractions.Messaging;
using DevFreela.Payments.Domain.Abstractions;

namespace DevFreela.Payments.Application.ExecutePayment
{
    public class ExecutePaymentCommandHandler : ICommandHandler<ExecutePaymentCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(ExecutePaymentCommand request, CancellationToken cancellationToken)
        {
            return Result.Success(new Guid());
        }
    }
}
