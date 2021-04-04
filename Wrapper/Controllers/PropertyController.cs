using Lib.Models.PropertyDetails;
using Lib.Services.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<PropertyController> _logger;

        public PropertyController(
            IPropertyService propertyService,
            ILogger<PropertyController> logger)
        {
            _propertyService = propertyService;
            _logger = logger;
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
                return BadRequest("Url parameters must contain non null property identifiers");
            }

            try
            {

                var data = await _propertyService.GetPropertyData(lookups.FirstOrDefault());

                return Ok(_propertyService.GetSewerResponse(data));

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<Lookup> lookups)
        {
            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest("Request body parameters must contain non null property identifiers");
            }

            try
            {
                var data = await _propertyService.GetPropertyData(lookups);

                return Ok(_propertyService.GetSewerResponse(data));

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}
