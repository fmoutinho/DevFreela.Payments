using DevFreela.Payments.Application.ExecutePayment;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string PAYMENT_QUEUE = "Payments";
        private const string PAYMENT_APPROVED_QUEUE = "PaymentsApproved";

        private readonly ILogger<ProcessPaymentConsumer> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ProcessPaymentConsumer(ILogger<ProcessPaymentConsumer> logger, IConnection connection, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _connection = connection;
            _serviceProvider = serviceProvider;

            // Criação do canal (IModel) no construtor
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: PAYMENT_QUEUE, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: PAYMENT_APPROVED_QUEUE, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<ExecutePaymentCommand>(paymentInfoJson);

                ProcessPayment(paymentInfo, stoppingToken);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(PAYMENT_QUEUE, false, consumer);

            return;
        }

        private async void ProcessPayment(ExecutePaymentCommand paymentInfo, CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<ISender>();

                var result = await sender.Send(paymentInfo, stoppingToken);
            }
        }
    }
}