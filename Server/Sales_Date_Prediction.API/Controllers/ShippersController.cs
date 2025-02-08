using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.AppWeb.Features.Shippers.Queries.GetAllShippers;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;

namespace Sales_Date_Prediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GetShipper
        [HttpGet("GetShipper")]
        public async Task<BaseResponse<IEnumerable<Shipper>>> GetShipper()
        {
            var result = await _mediator.Send(new GetAllShippersQuery());
            return result;
        }
    }
}
