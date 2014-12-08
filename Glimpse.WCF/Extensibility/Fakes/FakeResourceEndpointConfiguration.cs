using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeResourceEndpointConfiguration : ResourceEndpointConfiguration
    {
        protected override string GenerateUriTemplate(string resourceName, string baseUri, IEnumerable<ResourceParameterMetadata> parameters, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
