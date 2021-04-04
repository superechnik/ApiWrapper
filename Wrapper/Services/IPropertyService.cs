using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Models.HouseCanary;
using Lib.Models.PropertyDetails;
using Lib.Models.Sewer;

namespace Wrapper.Services
{
    public interface IPropertyService
    {
        public Task<Root> GetPropertyData(string address, int zipCode);

        public Task<IEnumerable<Root>> GetPropertyData(IEnumerable<Lookup> lookup);

        public SewerResponse GetSewerResponse(Root root);
        public IEnumerable<SewerResponse> GetSewerResponse(IEnumerable<Root> root);

    }
}
