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
        public Lookup(IQueryCollection queryCollection)
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
            
            foreach(var i in PropertyMap())
            {
                if (i.Value is not null)
                {
                    sb.Append($"{i.Key}={i.Value}&");
                }
                
            }

            //remove last ampersand
            if (sb.Length > 1)
            sb.Length--;

            return sb.ToString();
        }

        //This map to provide an iterable collection of props without using reflection
        private Dictionary<string,string?> PropertyMap() =>
            new()
            {
                {"Address", Address},
                {"Unit", Unit},
                {"City", City},
                {"State", State},
                {"Zipcode", Zipcode},
            };
    }
}