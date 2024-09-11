using DevFreela.Payments.Application.Abstractions.Messaging;
using DevFreela.Payments.Domain.Payments;

namespace DevFreela.Payments.Application.GetPayment
{
    public class GetPaymentQuery : IQuery<GetPaymentResponse>
    {
        public GetPaymentQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
