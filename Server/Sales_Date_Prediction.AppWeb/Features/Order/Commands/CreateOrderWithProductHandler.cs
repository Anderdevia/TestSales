using MediatR;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Data;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.AppWeb.Features.Order.Commands
{
    public class CreateOrderWithProductHandler : IRequestHandler<CreateOrderWithProductCommand, BaseResponse<bool>>
    {
        private readonly IOrdersRepository _ordersRepository;
        public CreateOrderWithProductHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<BaseResponse<bool>> Handle(CreateOrderWithProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderWithProduc = await _ordersRepository.PostCreateOrderWithProductAsync(request);
                if (orderWithProduc)
                {
                    return Response.SuccessResponse(true, true, 200, "OK");
                }
                else return Response.CustomResponse<bool>(204, "Error al crear la orden");
            }
            catch
            {
                return Response.CustomResponse<bool>(500, "Ha ocurrido un error");
            }
        }
    }
}
