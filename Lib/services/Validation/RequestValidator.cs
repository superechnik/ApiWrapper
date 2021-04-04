using System.Collections.Generic;
using Lib.Models.PropertyDetails;

namespace Lib.Services.Validation
{
    public static class RequestValidator
    {
        /// <summary>
        /// Iterates of list of request bodies and breaks if all values in any one of them are null
        /// </summary>
        /// <param name="lookups"></param>
        /// <returns>
        /// bool signifying if the values are missing
        /// </returns>
        public static bool ValuesMissing(IEnumerable<Lookup> lookups)
        {
            bool missingValue = false;

            foreach (var lookup in lookups)
            {
                missingValue =
                    lookup.Address is null ||
                    (
                        lookup.Zipcode is null &&
                        (
                            lookup.City is null ||
                            lookup.State is null
                        )
                    );

                if (missingValue)
                {
                    break;
                }
            }

            return missingValue;

        }

    }

}