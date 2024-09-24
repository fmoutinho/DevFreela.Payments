using DevFreela.Payments.Domain.Payments;

namespace DevFreela.Payments.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

        }

        public async Task<Payment?> GetById(Guid id)
        {
            return _context.Payments.FirstOrDefault(p => p.Id == id);
        }
    }
}
