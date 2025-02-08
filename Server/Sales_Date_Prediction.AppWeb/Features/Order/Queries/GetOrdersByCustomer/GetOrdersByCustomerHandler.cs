using MediatR;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Data;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerHandler : IRequestHandler<GetOrdersByCustomerQuery, BaseResponse<IEnumerable<OrdersByCustomerDTO>>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersByCustomerHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<BaseResponse<IEnumerable<OrdersByCustomerDTO>>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orderbycustomer = await _ordersRepository.GetOrderByCustomerAsync(request.custid);
                if (orderbycustomer.Count() > 0)
                {
                    return Response.SuccessResponse(orderbycustomer, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<OrdersByCustomerDTO>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<OrdersByCustomerDTO>>(500, "Ha ocurrido un error");
            }
        }
    }
}
