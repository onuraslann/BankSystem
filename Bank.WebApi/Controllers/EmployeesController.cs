using Bank.Core.BaseRepository.Abstract;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IServiceGeneric<Employee, EmployeeVM> _employeService;

        public EmployeesController(IServiceGeneric<Employee, EmployeeVM> employeService)
        {
            _employeService = employeService;
        }

        [HttpGet]

        public async Task<IActionResult> GetEmployee()
        {
            var employeeList = await _employeService.GetAllAsync();
            return ActionResultInstance(employeeList);
        }

        [HttpPost]
        public async Task<IActionResult> SetEmployee(EmployeeVM employeeVM)
        {
            var employeeList = await _employeService.AddAsync(employeeVM);
            return ActionResultInstance(employeeList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeVM  employeeVM)
        {
            var employeeList = await _employeService.Update(employeeVM,employeeVM.Id);
            return ActionResultInstance(employeeList);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(KeyVM keyVM)
        {
            var employeeList = await _employeService.Remove(keyVM.Id);
            return ActionResultInstance(employeeList);
        }
    }
}
