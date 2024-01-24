using AutoMapper;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
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

        return Ok(transactionDetails);
    }
}
