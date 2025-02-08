using MediatR;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Data;
using Sales_Date_Prediction.Domain.Shared;

namespace Sales_Date_Prediction.AppWeb.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, BaseResponse<IEnumerable<Employee>>>
    {

        private readonly IEmployeeRepository _employeeRepository;


        public GetAllEmployeesHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse<IEnumerable<Employee>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeeAsync();
                if (employees.Count() > 0)
                {
                    return Response.SuccessResponse(employees, true, 200, "OK");
                }
                else return Response.CustomResponse<IEnumerable<Employee>>(204, "No se encontraron datos");
            }
            catch
            {
                return Response.CustomResponse<IEnumerable<Employee>>(500, "Ha ocurrido un error");
            }
        }
    }
}
