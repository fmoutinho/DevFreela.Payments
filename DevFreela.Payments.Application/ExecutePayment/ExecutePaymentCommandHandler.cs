using DevFreela.Payments.Application.Abstractions.Messaging;
using DevFreela.Payments.Domain.Abstractions;
using DevFreela.Payments.Domain.Payments;

namespace DevFreela.Payments.Application.ExecutePayment
{
    public class ExecutePaymentCommandHandler : ICommandHandler<ExecutePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _paymentRepository;

        public ExecutePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<Guid>> Handle(ExecutePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = request.ToEntity();

            await _paymentRepository.AddAsync(payment);

            return Result.Success(payment.Id);
        }
    }
}
