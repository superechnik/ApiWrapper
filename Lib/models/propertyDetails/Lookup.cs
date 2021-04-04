#nullable enable

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace Lib.Models.PropertyDetails
{
    /// <summary>
    /// A model for a request body to the HouseCanary Property/Details api
    /// </summary>
    public class Lookup
    {
        public Lookup (IQueryCollection queryCollection)
        {
            Address = queryCollection.TryGetValue("Address", out var addressValue) ? addressValue.ToString() : null;
            Unit = queryCollection.TryGetValue("Unit", out var unitValue) ? unitValue.ToString() : null;
            State = queryCollection.TryGetValue("State", out var stateValue) ? stateValue.ToString() : null;
            City = queryCollection.TryGetValue("City", out var cityValue) ? cityValue.ToString() : null;
            Zipcode = queryCollection.TryGetValue("Zipcode", out var zipValue) ? zipValue.ToString() : null;
        }

        public Lookup()
        {
            
        }

        public string? Address { get; init; }
        public string? Unit { get; init; }
        public string? State { get; init; }
        public string? City { get; init; }
        public string? Zipcode { get; init; }

        public IEnumerable<Lookup> ToList() =>
            new List<Lookup>() { this };

        public string ToQueryString()
        {
            var sb = new StringBuilder("?");

            if (Address is not null)
            {
                sb.Append($"Address={Address}&");
            }

            if (Unit is not null)
            {
                sb.Append($"Unit={Unit}&");
            }

            if (State is not null)
            {
                sb.Append($"State={State}");
            }

            if (City is not null)
            {
                sb.Append($"City={City}");
            }

            if (Zipcode is not null)
            {
                sb.Append($"Zipcode={Zipcode}");
            }

            return sb.ToString();
        }

    }
}
