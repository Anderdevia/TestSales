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

namespace Sales_Date_Prediction.AppWeb.Features.Shippers.Queries.GetAllShippers
{
    public class GetAllShippersHandler : IRequestHandler<GetAllShippersQuery, BaseResponse<IEnumerable<Shipper>>>
    {
        private readonly IShipperRepository _shipperRepository;

        public GetAllShippersHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository= shipperRepository;
        }
        public async Task<BaseResponse<IEnumerable<Shipper>>> Handle(GetAllShippersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var shipper = await _shipperRepository.GetShipperAsync();
                if (shipper.Count() > 0)
                {
                    return Response.SuccessResponse(shipper, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<Shipper>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<Shipper>>(500, "Ha ocurrido un error");
            }
        }
    }
}
