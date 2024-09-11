using DevFreela.Payments.Application.Abstractions.Messaging;

namespace DevFreela.Payments.Application.ExecutePayment
{
    public record ExecutePaymentCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;
}
