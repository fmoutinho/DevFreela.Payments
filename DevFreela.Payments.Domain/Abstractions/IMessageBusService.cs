namespace DevFreela.Payments.Domain.Abstractions
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}
