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

namespace Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, BaseResponse<IEnumerable<Orders>>>
    {
        private readonly IOrdersRepository _ordersRepository;


        public GetOrdersHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<BaseResponse<IEnumerable<Orders>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _ordersRepository.GetOrdersAsync();
                if (orders.Count() > 0)
                {
                    return Response.SuccessResponse(orders, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<Orders>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<Orders>>(500, "Ha ocurrido un error");
            }
        }
    }
}
