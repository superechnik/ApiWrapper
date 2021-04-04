using System.Text.Json.Serialization;

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
            var sewer = SewerType;

            return sewer is not null && sewer == "Septic";

        }

    }
}