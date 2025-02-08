using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.AppWeb.Features.Order.Commands;
using Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrders;
using Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrdersByCustomer;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;
using System.Net;

namespace Sales_Date_Prediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GetOrders
        [HttpGet("GetOrders")]
        public async Task<BaseResponse<IEnumerable<Orders>>> GetOrders()
        {
            var result = await _mediator.Send(new GetOrdersQuery());
            return result;
        }

        // GET: api/GetOrdersByCustomer
        [HttpGet("GetOrdersByCustomer/{custid:int}")]
        public async Task<BaseResponse<IEnumerable<OrdersByCustomerDTO>>> GetOrdersByCustomer( int custid)
        {
            var result = await _mediator.Send(new GetOrdersByCustomerQuery(custid));
            return result;
        }

        // GET: api/PostNewOrder
        [HttpPost("PostNewOrder")]
        public async Task<BaseResponse<bool>> PostNewOrder([FromBody] CreateOrderWithProductCommand createOrderWithProductCommand )
        {
            var result = await _mediator.Send(createOrderWithProductCommand);
            return result;
        }

    }
}
