using Lib.Extensions;
using Lib.Models.PropertyDetails;
using Lib.Services.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrapper.Models;
using Wrapper.Services;
using Lib.Models.Error;
using Microsoft.AspNetCore.Http;

namespace Wrapper
{
    [Route("api/[controller]")]
    [ApiController]
    //Todo: add authorization
    [AllowAnonymous]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly ILogger<PropertyController> _logger;
        private readonly HouseCanaryOptions _options;
        public PropertyController(
            IPropertyService propertyService,
            ILogger<PropertyController> logger,
            IOptions<HouseCanaryOptions> options
            )
        {
            _propertyService = propertyService;
            _logger = logger;
            _options = options.Value;
        }

        /// <summary>
        /// Get a single SewerResponse from a Get request with query string params
        /// </summary>
        /// <param name="address"></param>
        /// <param name="unit"></param>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <param name="zipcode"></param>
        /// <returns>SewerResponse</returns>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string address,
            [FromQuery] string unit,
            [FromQuery] string state,
            [FromQuery] string city,
            [FromQuery] string zipcode
            )
        {

            //validate url parameters
            var lookups = new Lookup(HttpContext.Request.Query)
                .ToList();

            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest(
                    new ErrorResponse(ResponseMessages.GetResponseMessage(400), 400)
                    );
            }

            try
            {

                var data = await _propertyService
                    .GetPropertyData(lookups.FirstOrDefault(), _options.BaseUri);

                return Ok(data.GetSewerResponse());

            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new ErrorResponse(ex.Message, 500)
                );
            }

        }

        /// <summary>
        /// Get a list of sewer reponse from a post request with a list of body: Lookup
        /// </summary>
        /// <param name="lookups"></param>
        /// <returns>List of SewerResponse</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<Lookup> lookups)
        {
            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest(
                    new ErrorResponse(ResponseMessages.GetResponseMessage(400), 400)
                    );
            }

            try
            {
                var data = await _propertyService.GetPropertyData(lookups, _options.BaseUri);

                return Ok(data.GetSewerResponse());

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new ErrorResponse(ex.Message, 500)
                );
            }

        }

    }
}