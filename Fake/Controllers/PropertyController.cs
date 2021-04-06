using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Lib.Services.Mock;
using System.Collections.Generic;
using Lib.Models.PropertyDetails;
using Lib.Models.HouseCanary;
using Microsoft.Extensions.Logging;
using Lib.Services.Validation;
using Lib.Models.Error;
using Microsoft.AspNetCore.Http;

namespace Fake
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IResponseMocker _responseMocker;
        private readonly ILogger<PropertyController> _logger;
        private const string BadQueryRequestResponse = "Missing required parameter in the query string";
        private const string BadBodyRequestResponse = "Missing required parameter in the request body";

        public PropertyController(
            IResponseMocker responseMocker,
            ILogger<PropertyController> logger
            )
        {
            _responseMocker = responseMocker;
            _logger = logger;
        }

        /// <summary>
        /// This get endpoint returns property details for a single address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="zipCode"></param>
        /// <param name="unit"></param>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <returns>
        /// HouseCanary.Root
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Details(
            [FromQuery] string address,
            [FromQuery] string unit,
            [FromQuery] string state,
            [FromQuery] string city,
            [FromQuery] string zipcode
            )
        {
            //validate input
            var lookups = new Lookup(HttpContext.Request.Query)
                .ToList();

            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest(new BadRequestResponse(BadQueryRequestResponse, 400));
            }
            try
            {
                return await Task.Run(() => Ok(_responseMocker.MockResponse()));

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new BadRequestResponse(ex.Message, 500)
                );
            }

        }

        /// <summary>
        /// This post endpoint returns a list of property details for multiple addresses
        /// </summary>
        /// <param name="lookup"></param>
        /// <returns>
        /// A list of HouseCanary.Root
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Details([FromBody] IEnumerable<Lookup> lookup)
        {
            //validate model
            if (RequestValidator.ValuesMissing(lookup))
            {
                return BadRequest(new BadRequestResponse(BadBodyRequestResponse, 400));
            }

            try
            {
                IList<Root> listOfPropertyDetails = new List<Root>();

                foreach (var propertyDetail in lookup)
                {
                    var response = await Task.Run(() => _responseMocker.MockResponse());
                    listOfPropertyDetails.Add(response);
                }

                return Ok(listOfPropertyDetails);

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new BadRequestResponse(ex.Message, 500)
                );
            }

        }

    }
}