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
    public class CustomersController : BaseController
    {
        private readonly IServiceGeneric<Customer, CustomerVM> _serviceGeneric;
        private readonly ICustomerAS _customerAS;

        public CustomersController(IServiceGeneric<Customer, CustomerVM> serviceGeneric, ICustomerAS customerAS)
        {
            _serviceGeneric = serviceGeneric;
            _customerAS = customerAS;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerAS.GetAllAsync();
            return ActionResultInstance(customer);

        }

        [HttpPost]
        public async Task<IActionResult> SetCustomer([FromBody]CustomerVM customerVM)
        {
          
            return ActionResultInstance(await _customerAS.AddAsync(customerVM));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerVM customerVM)
        {
            var deleteCustomer = await _serviceGeneric.Update(customerVM,customerVM.Id);
            return ActionResultInstance(deleteCustomer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromBody]KeyVM keyVM)
        {
            var deleteCustomer = await _serviceGeneric.Remove(keyVM.Id);
            return ActionResultInstance(deleteCustomer);
        }
    }
}
