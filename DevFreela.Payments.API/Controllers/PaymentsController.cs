using DevFreela.Payments.Application.ExecutePayment;
using DevFreela.Payments.Application.GetPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly ISender _sender;

        public PaymentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPaymentQuery(id);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExecutePaymentCommand paymentCommand, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(paymentCommand, cancellationToken);

            return  CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
        }
    }
}
