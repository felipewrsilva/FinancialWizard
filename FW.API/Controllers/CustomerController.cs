using FW.Application.Interfaces;
using FW.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Create([FromBody] Customer customer)
    {
        var response = await _customerService.AddAsync(customer);
        const int NoCustomerAdded = 0;
        bool customerAdded = response > NoCustomerAdded;
        if (customerAdded)
            return Ok(customer);
        return BadRequest();
    }
}
