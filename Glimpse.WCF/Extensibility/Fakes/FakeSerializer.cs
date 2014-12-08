using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeSerializer : ISerializer
    {
        public string Serialize(object target)
        {
            throw new NotImplementedException();
        }

        public void RegisterSerializationConverters(IEnumerable<ISerializationConverter> converters)
        {
            throw new NotImplementedException();
        }
    }
}
