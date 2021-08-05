using System.Threading.Tasks;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;

        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var result = await _services.CreateExchange(customer);
            // await _services.CreateQueue(customer);

            if (result) {
                return BadRequest("An error has occurred");
            }

            return Ok();
        }
    }
}