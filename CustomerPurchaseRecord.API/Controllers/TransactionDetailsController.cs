using AutoMapper;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using CustomerPurchaseRecord.Entities.DbSet;
using CustomerPurchaseRecord.Entities.Dtos.Requests;
using CustomerPurchaseRecord.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPurchaseRecord.API.Controllers;


public class TransactionDetailsController : BaseController
{
    public TransactionDetailsController(
        IUnitOfWork unitOfWork,
        IMapper mapper)
   : base(unitOfWork, mapper)
    {
    }

    [HttpGet]                   
    public async Task<IActionResult> GetAll()
    {
        var transactionDetails = await _unitOfWork.TransactionDetails.GetAll();

        return Ok(_mapper.Map<IEnumerable<GetTransactionDetailDto>>(transactionDetails));
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetCustomerTransaction(int customerId)
    {
        var customerTransaction = await _unitOfWork.TransactionDetails.GetCustomerTransaction(customerId);

        return Ok(_mapper.Map<IEnumerable<GetTransactionDetailDto>>(customerTransaction));
    }

    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetTransactionDetail(int transactionId)
    {
        var result = await _unitOfWork.TransactionDetails.GetById(transactionId);

        return Ok(_mapper.Map<IEnumerable<GetTransactionDetailDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionDetailDto transactionDetail)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<TransactionDetails>(transactionDetail);

        await _unitOfWork.TransactionDetails.Add(result);

        await _unitOfWork.SaveAsync();

        return CreatedAtAction(nameof(GetTransactionDetail), new { transactionId = result.CustomerId }, result);
    }
}
