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
        private readonly IEmployeeAS _employeeAS;

        public EmployeesController(IEmployeeAS employeeAS)
        {
            _employeeAS = employeeAS;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {

            var result = await _employeeAS.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> SetEmployee([FromBody] EmployeeVM employeeVM)
        {

            var result = await _employeeAS.AddAsync(employeeVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeVM employeeVM,int id)
        {

            var result = await _employeeAS.Update(employeeVM,id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> UpdateEmployee([FromBody] KeyVM keyVM)
        {

            var result = await _employeeAS.Remove(keyVM.Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
