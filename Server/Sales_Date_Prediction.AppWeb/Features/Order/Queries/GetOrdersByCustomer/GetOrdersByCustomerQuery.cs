using MediatR;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrdersByCustomer
{
    public record GetOrdersByCustomerQuery(int custid) : IRequest<BaseResponse<IEnumerable<OrdersByCustomerDTO>>>;
}
