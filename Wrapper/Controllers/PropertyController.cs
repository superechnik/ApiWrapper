using Lib.Models.PropertyDetails;
using Lib.Services.Validation;
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
        public async Task<IActionResult> Get (
            [FromQuery] string address,
            [FromQuery] string unit,
            [FromQuery] string state,
            [FromQuery] string city,
            [FromQuery] string zipcode
            )
        {
            //validate url parameters
            IEnumerable<Lookup> lookups = new List<Lookup>()
            {
                new Lookup()
                {
                    Address = address,
                    Unit = unit,
                    State = state,
                    City = city,
                    Zipcode = zipcode
                }
            };

            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest("Url parameters must contain at least one non null value");
            }
            
            var data = await _propertyService.GetPropertyData(lookups.FirstOrDefault());

            return Ok(_propertyService.GetSewerResponse(data));

        }

        [HttpPost]
        public async Task<IActionResult> Pst([FromBody] IEnumerable<Lookup> lookups)
        {
            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest("Request body parameters must contain at least one non null value");
            }

            var data = await _propertyService.GetPropertyData(lookups);

            return Ok(_propertyService.GetSewerResponse(data));
        }
    }
}
