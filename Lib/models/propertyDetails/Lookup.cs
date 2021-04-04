#nullable enable

namespace Lib.Models.PropertyDetails
{
    /// <summary>
    /// A model for a request body to the HouseCanary Property/Details api
    /// </summary>
    public class Lookup
    {
        public string? Address { get; init; }
        public string? Unit { get; init; }
        public string? State { get; init; }
        public string? City { get; init; }
        public string? Zipcode { get; init; }
    }
}
