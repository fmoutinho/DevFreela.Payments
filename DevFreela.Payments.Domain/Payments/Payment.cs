using DevFreela.Payments.Domain.Abstractions;

namespace DevFreela.Payments.Domain.Payments
{
    public class Payment : Entity
    {
        public Payment(Guid id, string creaditCardNumber, string cvv, string expiresAt, string fullName):base(id)
        {
            CreaditCardNumber = creaditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
        }

        public string CreaditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
