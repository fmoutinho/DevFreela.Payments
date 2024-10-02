namespace DevFreela.Payments.Application.ExecutePayment
{
    public class PaymentExecutedIntegrationEvent
    {
        public PaymentExecutedIntegrationEvent(int idProject , Guid idPayment)
        {
            IdProject = idProject;
            IdPayment = idPayment;
        }

        public int IdProject { get; private set; }
        public Guid IdPayment { get; private set; }
    }
}
