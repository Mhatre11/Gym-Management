using Api.Models;
using Api.Repostories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPaymentsAsync()
        {
            return Ok(await _paymentRepository.GetAllPaymentsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPaymentByIdAsync(int id)
        {
            return Ok(await _paymentRepository.GetPaymentByIdAsync(id));
        }

        [HttpPost("create-payment")]
        public async Task<ActionResult> AddPaymentAsync([FromBody] Payment payment)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _paymentRepository.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentByIdAsync), new { id = payment.ID }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaymentAsync(int id, Payment payment)
        {
            await _paymentRepository.UpdatePaymentAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentAsync(int id)
        {
            await _paymentRepository.GetPaymentByIdAsync(id);
            return NoContent();
        }
    }
}