using Bank.Domain.ViewModels;
using Bank.Service.ApplicationServices.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditsController : ControllerBase
    {
        private readonly ICreditAS _creditAs;

        public CreditsController(ICreditAS creditAs)
        {
            _creditAs = creditAs;
        }

        [HttpPost]
        public async Task<IActionResult> SetCredit([FromBody] CreditVM creditVM)
        {
            var result = await _creditAs.AddAsync(creditVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCredit()
        {
            var listModel = await _creditAs.GetAllAsync();
            if (listModel.Success)
            {
                return Ok(listModel);
            }
            return BadRequest(listModel);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCredit([FromBody]KeyVM keyVM)
        {

            var deletedModel = await _creditAs.DeleteAsync(keyVM.Id);
            if (deletedModel.Success)
            {
                return Ok(deletedModel);
            }
            return BadRequest(deletedModel);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCredit([FromBody]UpdateCreditVM updateCreditVM, int id)
        {

            var updatedModel = await _creditAs.UpdateAsync(updateCreditVM, id);
            if (updatedModel.Success)
            {
                return Ok(updatedModel);
            }
            return BadRequest(updatedModel);
        }
    }
}
