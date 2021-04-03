using Xunit;
using Lib.Services.Mock;

namespace Fake.Tests
{
    public class MockedResponseTests
    {
        private readonly IResponseMocker _responseMocker;

        public MockedResponseTests()
        {
            _responseMocker = new ResponseMocker();
        }

        [Fact]
        public void MockResponseReturnsObject()
        {

            var response = _responseMocker.MockResponse();

            Assert.NotNull(response);

        }

        [Fact]
        public void MockResponseHasSewerData()
        {
            var response = _responseMocker.MockResponse();

            Assert.NotNull(response.PropertyDetails.Result.Property.Sewer);
        }

    }
}
