using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.AppWeb.Features.Products.Queries.GetAllProducts;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;

namespace Sales_Date_Prediction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GetProduct
        [HttpGet("GetProduct")]
        public async Task<BaseResponse<IEnumerable<Product>>> GetProduct()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return result;
        }
    }
}
