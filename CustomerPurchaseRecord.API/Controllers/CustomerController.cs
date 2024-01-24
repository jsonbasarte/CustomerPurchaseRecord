using AutoMapper;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using CustomerPurchaseRecord.Entities.DbSet;
using CustomerPurchaseRecord.Entities.Dtos.Requests;
using CustomerPurchaseRecord.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPurchaseRecord.API.Controllers;

public class CustomerController : BaseController
{

    public CustomerController(
        IUnitOfWork unitOfWork, 
        IMapper mapper
     ) : base(unitOfWork, mapper) {}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customer = await _unitOfWork.Customers.GetAll();

        return Ok(_mapper.Map<IEnumerable<GetCustomerDto>>(customer));
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomer(int customerId)
    {
        var customer = await _unitOfWork.Customers.GetById(customerId);

        if (customer == null) 
            return NotFound();

        return Ok(_mapper.Map<GetCustomerDto>(customer));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Customer>(customer);

        await _unitOfWork.Customers.Add(result);

        await _unitOfWork.SaveAsync();

        return CreatedAtAction(nameof(GetCustomer), new { customerId = result.Id }, result);
    }
}
