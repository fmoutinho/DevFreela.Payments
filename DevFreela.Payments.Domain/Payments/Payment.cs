using DevFreela.Payments.Domain.Abstractions;

namespace DevFreela.Payments.Domain.Payments
{
    public class Payment : Entity
    {
        public Payment(int projectId, string creditCardNumber, string cvv, DateOnly expiresAt, string fullName)
        {
            ProjectId = projectId;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
        }

        public int ProjectId { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public DateOnly ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
