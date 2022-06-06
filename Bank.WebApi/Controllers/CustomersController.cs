using Bank.Core.BaseRepository.Abstract;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly IServiceGeneric<Customer, CustomerVM> _serviceGeneric;

        public CustomersController(IServiceGeneric<Customer, CustomerVM> serviceGeneric)
        {
            _serviceGeneric = serviceGeneric;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _serviceGeneric.GetAllAsync();
            return ActionResultInstance(customer);

        }

        [HttpPost]
        public async Task<IActionResult> SetCustomer(CustomerVM customerVM)
        {
          
            return ActionResultInstance(await _serviceGeneric.AddAsync(customerVM));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerVM customerVM)
        {
            var deleteCustomer = await _serviceGeneric.Update(customerVM,customerVM.Id);
            return ActionResultInstance(deleteCustomer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(KeyVM keyVM)
        {
            var deleteCustomer = await _serviceGeneric.Remove(keyVM.Id);
            return ActionResultInstance(deleteCustomer);
        }
    }
}
