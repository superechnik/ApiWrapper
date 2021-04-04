using Lib.Models.HouseCanary;
using Lib.Models.Sewer;
using System.Collections.Generic;

namespace Lib.Extensions
{
    public static class RootExtensions
    {

        public static SewerResponse GetSewerResponse(this Root root) =>
            new SewerResponse()
            {
                SewerType = root.SewerType,
                IsSeptic = root.IsSeptic()
            };
        public static IEnumerable<SewerResponse> GetSewerResponse(this IEnumerable<Root> roots)
        {
            foreach (var root in roots)
            {
                yield return root.GetSewerResponse();
            }
        }
    }
}