using DevFreela.Payments.Application.Abstractions.Messaging;

namespace DevFreela.Payments.Application.PaymentCommands
{
    public record PaymentCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;
}
