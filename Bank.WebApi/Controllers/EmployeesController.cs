using Bank.Core.BaseRepository.Abstract;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Bank.Service.ApplicationServices.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceGeneric<Employee, EmployeeVM> _employeService;
        private readonly IEmployeeAS _employeeAS;
        public EmployeesController(IServiceGeneric<Employee, EmployeeVM> employeService, IEmployeeAS employeeAS)
        {
            _employeService = employeService;
            _employeeAS = employeeAS;
        }

    }
}
