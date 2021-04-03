using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lib.models.propertyDetails
{
    public class Root
    {
        [JsonPropertyName("property/details")]
        public PropertyDetails PropertyDetails { get; set; }
    }
}
