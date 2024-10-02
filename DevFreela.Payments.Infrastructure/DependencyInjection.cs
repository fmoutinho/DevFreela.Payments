using DevFreela.Payments.Domain.Abstractions;
using DevFreela.Payments.Domain.Payments;
using DevFreela.Payments.Infrastructure.MessageBus;
using DevFreela.Payments.Infrastructure.Persistence;
using DevFreela.Payments.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace DevFreela.Payments.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration)
                .AddRabbitMQ(configuration);

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevFreelaCS");
            services.AddDbContext<PaymentDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }

        private static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtém as configurações do RabbitMQ a partir do arquivo de configuração, se necessário
            var rabbitMQHostName = configuration.GetSection("RabbitMQ:HostName").Value ?? "localhost";

            var factory = new ConnectionFactory() { HostName = rabbitMQHostName };

            // Registra a conexão com o RabbitMQ como Singleton
            services.AddSingleton<IConnection>(sp => factory.CreateConnection());

            // Registra o canal (IModel) como Scoped
            services.AddScoped<IModel>(sp =>
            {
                var connection = sp.GetRequiredService<IConnection>();
                return connection.CreateModel();
            });
        }
    }
}
