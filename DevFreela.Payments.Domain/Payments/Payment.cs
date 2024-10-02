using DevFreela.Payments.Domain.Abstractions;

namespace DevFreela.Payments.Domain.Payments
{
    public class Payment : Entity
    {
        public Payment(int projectId, string creditCardNumber, string cvv, DateOnly expiresAt, string fullName, decimal value)
        {
            ProjectId = projectId;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Value = value;
        }
        public int ProjectId { get;  set; }
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public DateOnly ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Value { get; set; }
    }
}
