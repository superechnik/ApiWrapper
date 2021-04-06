using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Models.HouseCanary;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Lib.Models.PropertyDetails;
using System.IO;

namespace Lib.Services.Wrapper
{
    public class PropertyService : IPropertyService
    {
        private readonly HttpClient _http;
        public PropertyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Root> GetPropertyData(Lookup lookup, string baseUri)
        {
            return await _http.GetFromJsonAsync<Root>(Path.Combine(baseUri, lookup.ToQueryString()));
        }

        public async Task<IEnumerable<Root>> GetPropertyData(IEnumerable<Lookup> lookup, string baseUri)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var x = await _http.PostAsJsonAsync(baseUri, lookup);

            return JsonSerializer.Deserialize<IEnumerable<Root>>(await x.Content.ReadAsStringAsync(), options);
        }

    }
}
