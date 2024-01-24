using AutoMapper;
using CustomerPurchaseRecord.DataService.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPurchaseRecord.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
