using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.AppWeb.Features.Employees.Queries.GetAllEmployees;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;

namespace Sales_Date_Prediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Employee
        [HttpGet("GetEmployee")]
        public async Task<BaseResponse<IEnumerable<Employee>>> GetCustomers()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return result;
        }
    }
}
