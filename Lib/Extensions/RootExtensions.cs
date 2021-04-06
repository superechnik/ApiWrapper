using Lib.Models.HouseCanary;
using Lib.Models.Sewer;
using System.Collections.Generic;

namespace Lib.Extensions
{
    public static class RootExtensions
    {
        /// <summary>
        /// Given a root, returns a SewerResonse from the data
        /// </summary>
        /// <param name="root"></param>
        /// <returns>SewerResponse</returns>
        public static SewerResponse GetSewerResponse(this Root root) =>
            new()
            {
                SewerType = root.SewerType(),
                IsSeptic = root.IsSeptic()
            };

        /// <summary>
        /// Given a list of roots, returns a list of SewerResonse from the data
        /// </summary>
        /// <param name="roots"></param>
        /// <returns>List of SewerResponse</returns>
        public static IEnumerable<SewerResponse> GetSewerResponse(this IEnumerable<Root> roots)
        {
            foreach (var root in roots)
            {
                yield return root.GetSewerResponse();
            }
        }
    }
}