using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.AppWeb.Features.SalesDatePrediction.Queries.GetAllSalesDatePrediction;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;

namespace Sales_Date_Prediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesDatePredictionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesDatePredictionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GetSalesDatePrediction
        [HttpGet("GetSalesDatePrediction")]
        public async Task<BaseResponse<IEnumerable<SalesDatePredictionDTO>>> GetSalesDatePrediction()
        {
            var result = await _mediator.Send(new GetAllSalesDatePredictionQuery());
            return result;
        }
    }
}
