using System.Threading.Tasks;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressRepository _rep;
        public AddressController(ILogger<AddressController> logger, IAddressRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            _logger.LogInformation("Iniciou a busca de endereço por Id");

            var address = await _rep.GetById(id);

            return address;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            _logger.LogInformation("Iniciou o proceso de inserção de endereço");

            await _rep.Insert(address);

            return Ok();            
        }
    }
}