using Dapper;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Data;
using Sales_Date_Prediction.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Access.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<Customer?> GetByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 6);

                using (var results = await connection.QueryMultipleAsync("dbo.Sp_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var customers = await results.ReadAsync<Customer>();
                    return (customers);
                }
            }
        }
    }
}
