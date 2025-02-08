using MediatR;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Data;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.AppWeb.Features.Products.Queries.GetAllProducts
{
    internal class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, BaseResponse<IEnumerable<Product>>>
    {
        private readonly IProductRepository _productRepository;


        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<BaseResponse<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetProductAsync();
                if (product.Count() > 0)
                {
                    return Response.SuccessResponse(product, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<Product>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<Product>>(500, "Ha ocurrido un error");
            }
        }
    }
}
