using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Domain.Entities
{
    public class Orders
    {
        public int orderid { get; set; }
        public int custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public int shipperid { get; set; }
        public double freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string shipregion { get; set; }
        public string shippostalcode { get; set; }
        public string shipcountry { get; set; }
    }
}
