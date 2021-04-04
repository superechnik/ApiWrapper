using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Lib.Services.Mock;
using System.Collections.Generic;
using Lib.Models.PropertyDetails;
using Lib.Models.HouseCanary;

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

        /// <summary>
        /// This get endpoint returns property details for a single address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="zipCode"></param>
        /// <returns>
        /// HouseCanary.Root
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string address, int zipCode)
        {
            return await Task.Run( () => Ok(_responseMocker.MockResponse()));
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
            IList<Root> listOfPropertyDetails = new List<Root>();

            foreach (var propertyDetail in lookup)
            {
                var response = await Task.Run(() => _responseMocker.MockResponse());
                listOfPropertyDetails.Add(response);
            }

            return Ok(listOfPropertyDetails);

        }

    }
}