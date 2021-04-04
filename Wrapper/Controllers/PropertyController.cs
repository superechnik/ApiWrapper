﻿using Lib.Extensions;
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
        private readonly ILogger<PropertyController> _logger;

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
            var lookups = new Lookup(HttpContext.Request.Query)
                .ToList();

            if (RequestValidator.ValuesMissing(lookups))
            {
                return BadRequest("Url parameters must contain non null property identifiers");
            }

            try
            {

                var data = await _propertyService.GetPropertyData(lookups.FirstOrDefault());

                return Ok(data.GetSewerResponse());

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

                return Ok(data.GetSewerResponse());

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}
