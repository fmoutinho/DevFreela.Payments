using DevFreela.Payments.Domain.Payments;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Payments.Infrastructure.Persistence
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(e => e.HasKey(s => s.Id));

            base.OnModelCreating(modelBuilder);
        }
    }
}
