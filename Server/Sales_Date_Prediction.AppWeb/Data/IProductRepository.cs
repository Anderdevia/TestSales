using Sales_Date_Prediction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Domain.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();

    }
}
