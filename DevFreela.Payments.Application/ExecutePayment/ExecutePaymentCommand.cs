using DevFreela.Payments.Application.Abstractions.Messaging;
using DevFreela.Payments.Domain.Payments;

namespace DevFreela.Payments.Application.ExecutePayment
{
    public record ExecutePaymentCommand(
         int ProjectId,
         string CreditCardNumber,
         string Cvv,
         DateOnly ExpiresAt,
         string FullName,
         double Value) : ICommand<Guid>
    {
        public Payment ToEntity()
        {
            return new Payment(CreditCardNumber, Cvv, ExpiresAt, FullName, Value);
        }
    }
}
