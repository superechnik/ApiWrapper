using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Wrapper.Tests
{
    public class IntegrationTests
    {
        const string baseUri = "https://localhost:5001/api/property";

        [Theory]
        [InlineData("?Address=123 Happy Ln&Unit=2A&City=Mendon&State=WY&Zipcode=99455")]
        [InlineData("?Address=123 Happy Ln&Zipcode=99455")]
        [InlineData("?Address=123 Happy Ln&City=Mendon&State=WY")]
        public async Task GetRequestIsSuccess(string query)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(Path.Combine(baseUri, query));

            Assert.True(response.IsSuccessStatusCode);
            
        }

        [Theory]
        [InlineData("?Unit=2A&City=Mendon&State=WY&Zipcode=99455")]
        [InlineData("?Address=123 Happy Ln")]
        [InlineData("?Address=123 Happy Ln&City=Mendon")]
        [InlineData("?Address=123 Happy Ln&State=MD")]
        public async Task GetRequestIs400(string query)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(Path.Combine(baseUri, query));

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);

        }

    }
}
