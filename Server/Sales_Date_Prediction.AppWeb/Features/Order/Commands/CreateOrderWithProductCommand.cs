using MediatR;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.AppWeb.Features.Order.Commands
{
    public class CreateOrderWithProductCommand : IRequest<BaseResponse<bool>>
    {
        public int custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public int shipperid { get; set; }
        public double freight { get; set; }
        public string shipname { get; set; } = String.Empty;
        public string shipaddress { get; set; } = String.Empty;
        public string shipcity { get; set; } = String.Empty;
        public string shipcountry { get; set; } = String.Empty;
        public int productid { get; set; }
        public double unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }
    }
}
