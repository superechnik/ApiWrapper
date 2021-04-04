using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Models.HouseCanary;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Lib.Models.PropertyDetails;

namespace Wrapper.Services
{
    public class PropertyService : IPropertyService
    {
        const string endpoint = "https://localhost:4431/api/property?address=123+Main+St&zipcode=94132";
        private readonly HttpClient _http;
        public PropertyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Root> GetPropertyData(Lookup lookup)
        {
            return await _http.GetFromJsonAsync<Root>(endpoint);

        }

        public async Task<IEnumerable<Root>> GetPropertyData(IEnumerable<Lookup> lookup)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var x = await _http.PostAsJsonAsync("https://localhost:4431/api/property", lookup);

            return JsonSerializer.Deserialize<IEnumerable<Root>>(await x.Content.ReadAsStringAsync(), options);
        }
        
    }
}
