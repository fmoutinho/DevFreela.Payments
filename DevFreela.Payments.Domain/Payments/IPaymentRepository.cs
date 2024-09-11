using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Payments.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment> GetById(Guid id);
    }
}
