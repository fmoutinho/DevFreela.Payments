using DevFreela.Payments.Domain.Abstractions;

namespace DevFreela.Payments.Domain.Payments
{
    public class Payment : Entity
    {
        public Payment(string creditCardNumber, string cvv, DateOnly expiresAt, string fullName, double value)
        {
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Value = value;
        }
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public DateOnly ExpiresAt { get; set; }
        public string FullName { get; set; }
        public double Value { get; set; }
    }
}
