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
    public class CustomersController : ControllerBase
    {
      
        private readonly ICustomerAS _customerAS;

        public CustomersController( ICustomerAS customerAS)
        {
            
            _customerAS = customerAS;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerAS.GetAllAsync();
            if (customer.Success)
            {
                return Ok(customer);
            }
            return BadRequest(customer);

        }

        [HttpPost]
        public async Task<IActionResult> SetCustomer([FromBody] CustomerVM customerVM)
        {
            var customer = await _customerAS.AddAsync(customerVM);

            if (customer.Success)
            {
                return Ok(customer);
            }
            return BadRequest(customer);

        }

        [HttpDelete]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerVM customerVM,int id)
        {
            var deleteCustomer = await _customerAS.Update(customerVM, id);
            if (deleteCustomer.Success)
            {
                return Ok(deleteCustomer);
            }
            return BadRequest(deleteCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteCustomer([FromBody] KeyVM keyVM)
        {
            var deleteCustomer = await _customerAS.Remove(keyVM.Id);
            if (deleteCustomer.Success)
            {
                return Ok(deleteCustomer);
            }
            return BadRequest(deleteCustomer);
        }
    }
}
