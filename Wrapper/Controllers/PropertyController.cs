using Lib.Models.PropertyDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrapper.Services;

namespace Wrapper
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string address, int zipCode)
        {
            var data = await _propertyService.GetPropertyData(address, zipCode);

            return Ok(_propertyService.GetSewerResponse(data));

        }

        [HttpPost]
        public async Task<IActionResult> Pst([FromBody] IEnumerable<Lookup> lookup)
        {
            var data = await _propertyService.GetPropertyData(lookup);

            return Ok(_propertyService.GetSewerResponse(data));
        }
    }
}
