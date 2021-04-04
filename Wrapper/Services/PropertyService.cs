using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Models.HouseCanary;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Lib.Models.PropertyDetails;
using System.IO;
using System;
using System.Diagnostics;

namespace Wrapper.Services
{
    public class PropertyService : IPropertyService
    {
        const string baseUrl = "https://localhost:4431/api/property";
        
        private readonly HttpClient _http;
        public PropertyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Root> GetPropertyData(Lookup lookup)
        {
            Debug.WriteLine($"oh!: {lookup.ToQueryString()}");
            return await _http.GetFromJsonAsync<Root>(Path.Combine(baseUrl,lookup.ToQueryString()));
        }

        public async Task<IEnumerable<Root>> GetPropertyData(IEnumerable<Lookup> lookup)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var x = await _http.PostAsJsonAsync(baseUrl, lookup);

            return JsonSerializer.Deserialize<IEnumerable<Root>>(await x.Content.ReadAsStringAsync(), options);
        }

        
    }
}
