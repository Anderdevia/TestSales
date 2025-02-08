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

namespace Sales_Date_Prediction.AppWeb.Features.SalesDatePrediction.Queries.GetAllSalesDatePrediction
{
    public class GetAllSalesDatePredictionHandler : IRequestHandler<GetAllSalesDatePredictionQuery, BaseResponse<IEnumerable<SalesDatePredictionDTO>>>
    {
        private readonly ISalesDatePredictionRepository _salesDatePredictionRepository;


        public GetAllSalesDatePredictionHandler(ISalesDatePredictionRepository salesDatePredictionRepository)
        {
            _salesDatePredictionRepository = salesDatePredictionRepository;
        }
        public async Task<BaseResponse<IEnumerable<SalesDatePredictionDTO>>> Handle(GetAllSalesDatePredictionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var salesdateprediction = await _salesDatePredictionRepository.GetSalesDatePrediction();
                if (salesdateprediction.Count() > 0)
                {
                    return Response.SuccessResponse(salesdateprediction, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<SalesDatePredictionDTO>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<SalesDatePredictionDTO>>(500, "Ha ocurrido un error");
            }
        }
    }
}
