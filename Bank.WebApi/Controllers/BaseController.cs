using Bank.Core.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {


            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };

        } 
    }
}
