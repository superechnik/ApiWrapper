using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = Lib.models;

namespace Fake
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string address, int zipCode)
        {
            var assessment = new models.propertyDetails.Assessment();
            var property = new models.propertyDetails.Property();
          
            var result = new models.propertyDetails.Result()
            {
                Assessment = assessment,
                Property = property
            };

            var propertyDetails = new models.propertyDetails.PropertyDetails()
            {
                Result = result
            };

            var response = new models.propertyDetails.Root()
            {
                PropertyDetails = propertyDetails
            };
            

            return await Task.Run(() => Ok(response));
        }

    }
}