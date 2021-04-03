using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Fake.Services;

namespace Fake
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IResponseMocker _responseMocker;

        public PropertyController(IResponseMocker responseMocker)
        {
            _responseMocker = responseMocker;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string address, int zipCode)
        {
            return await Task.Run( () => Ok(_responseMocker.MockResponse()));
        }

    }
}