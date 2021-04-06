using Lib.Models.PropertyDetails;
using Lib.Services.Validation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Wrapper.Tests
{
    public class ValidationTests
    {
        [Theory]
        [InlineData("address", "city", "state", "unit", "zip")]
        [InlineData("address", null, "state", "unit", "zip")]
        [InlineData("address", "city", null, "unit", "zip")]
        [InlineData("address", null, null, null, "zip")]
        [InlineData("address", "city", "state", null, null)]
        public void AddressZipCityStateComboOk(string address, string city, string state, string unit, string zipcode)
        {
            var lookups = new List<Lookup>()
            {
                new Lookup()
                {
                    Address = address,
                    City = city,
                    State = state,
                    Unit = unit,
                    Zipcode = zipcode
                }
            };

            var result = RequestValidator.ValuesMissing(lookups);

            Assert.False(result);
        }

        [Theory]
        [InlineData(null, "city", "state", "unit", "zip")]
        [InlineData("address", null, "state", "unit", null)]
        [InlineData("address", "city", null, "unit", null)]
        public void MissingAddressOrValidComboBad(string address, string city, string state, string unit, string zipcode)
        {
            var lookups = new List<Lookup>()
            {
                new Lookup()
                {
                    Address = address,
                    City = city,
                    State = state,
                    Unit = unit,
                    Zipcode = zipcode
                }
            };

            var result = RequestValidator.ValuesMissing(lookups);

            Assert.True(result);

        }
    }
}
