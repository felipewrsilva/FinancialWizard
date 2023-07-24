using AutoMapper;
using FW.API.ViewModels.RequestModels;
using FW.API.ViewModels.ResponseModels;
using FW.Application.Interfaces;
using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using Microsoft.AspNetCore.Mvc;

namespace FW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerCreateRequest customerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Customer customer = _mapper.Map<Customer>(customerRequest);

        int customerId = await _customerService.AddAsync(customer);

        CustomerResponse customerResponse = _mapper.Map<CustomerResponse>(customer);

        if (customerId > 0)
            return CreatedAtAction(nameof(Get), new { id = customerResponse.Id }, customerResponse);

        return BadRequest("Failed to create customer.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        CustomerId customerId = new(id);
        Customer? customer = await _customerService.GetByIdAsync(customerId);

        if (customer == null)
            return NotFound();

        CustomerResponse customerResponse = _mapper.Map<CustomerResponse>(customer);

        return Ok(customerResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        CustomerId customerId = new(id);
        var registriesAltered = await _customerService.DeleteAsync(customerId);

        if (registriesAltered == 0)
            return NotFound();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateRequest customerRequest)
    {
        Customer customer = _mapper.Map<Customer>(customerRequest);
        var registriesAltered = await _customerService.UpdateAsync(customer);

        if (registriesAltered == 0)
            return NotFound();

        return Ok();
    }
}
