using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;

namespace Glimpse.WCF.Extensibility.Fakes
{
    class FakeHtmlEncoder : IHtmlEncoder
    {
        public string HtmlAttributeEncode(string input)
        {
            throw new NotImplementedException();
        }
    }
}
