using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Lib.Models.Sewer;

namespace Lib.Models.HouseCanary
{
    public class Root
    {
        [JsonPropertyName("property/details")]
        public PropertyDetails PropertyDetails { get; set; }

        public string SewerType =>
            PropertyDetails
                .Result
                .Property
                .Sewer;

        public bool IsSeptic()
        {
            var sewer = PropertyDetails
                .Result
                .Property
                .Sewer;

            return sewer is not null && sewer == "Septic";

        }

    }
}
