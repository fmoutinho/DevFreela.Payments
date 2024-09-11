using DevFreela.Payments.Application.PaymentCommands;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentCommand paymentCommand)
        {
            return null;
        }
    }
}
