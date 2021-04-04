using Lib.Models.PropertyDetails;
using Xunit;

namespace Wrapper.Tests
{
    public class LookupTests
    {
        [Fact]
        public void LoggerQueryBuilderWorksWithAllValues()
        {
            var lookup = new Lookup()
            {
                Address = "123 Happy Ln",
                City = "Mendon",
                State = "WY",
                Unit = "2A",
                Zipcode = "99455"
            };

            var actual = lookup.ToQueryString();
            var expect = "?Address=123 Happy Ln&Unit=2A&City=Mendon&State=WY&Zipcode=99455";

            Assert.Equal(expect, actual);
        }

        [Fact]
        public void LoggerqueryBuilderReturnsQuestionMarkWithNoValues()
        {
            var lookup = new Lookup();

            var actual = lookup.ToQueryString();
            var expect = "?";

            Assert.Equal(expect, actual);

        }
    }
}
