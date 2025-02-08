using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Sales_Date_Prediction.Access.Data;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.AppWeb.Features.Employees.Queries.GetAllEmployees;
using Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrders;
using Sales_Date_Prediction.AppWeb.Features.Products.Queries.GetAllProducts;
using Sales_Date_Prediction.AppWeb.Features.Shippers.Queries.GetAllShippers;
using Sales_Date_Prediction.Domain.Data;
using System.Data;

namespace Sales_Date_Prediction.Access
{
    public static class AccessIndependencyInjection
    {
        public static IServiceCollection AddAccess(this IServiceCollection services, string connectionString)
        {
            // Registrar conexión con Dapper
            services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<GetCustomersQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetAllEmployeesQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetOrdersQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetAllShippersQuery>();
            });

            // Registrar el repositorio
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISalesDatePredictionRepository, SalesDatePredictionRepository>();

            return services;
        }
    }
}
