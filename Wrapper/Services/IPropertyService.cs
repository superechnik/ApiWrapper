using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Models.HouseCanary;
using Lib.Models.PropertyDetails;

namespace Wrapper.Services
{
    public interface IPropertyService
    {
        public Task<Root> GetPropertyData(Lookup lookup,string baseUri);

        public Task<IEnumerable<Root>> GetPropertyData(IEnumerable<Lookup> lookup, string baseUri);

    }
}
