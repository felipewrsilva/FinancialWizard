using FW.Application.Interfaces;
using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using Microsoft.AspNetCore.Mvc;

namespace FW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int customerId = await _customerService.AddAsync(customer);

            if (customerId > 0)
                return CreatedAtAction(nameof(Get), new { id = customerId }, customer);

            return BadRequest("Failed to create customer.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customerId = new CustomerId(id);
            var customer = await _customerService.GetByIdAsync(customerId);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
