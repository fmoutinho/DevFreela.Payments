using DevFreela.Payments.Application.Abstractions.Messaging;
using DevFreela.Payments.Domain.Abstractions;
using DevFreela.Payments.Domain.Payments;

namespace DevFreela.Payments.Application.GetPayment
{
    public class GetPaymentQueryHandler : IQueryHandler<GetPaymentQuery, GetPaymentResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<GetPaymentResponse>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetById(request.Id);

            return GetPaymentResponse.FromEntity(result);
        }
    }
}
