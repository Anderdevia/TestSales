using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Domain.DTOs
{
    public class OrdersByCustomerDTO
    {
        public int orderid { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
    }
}
