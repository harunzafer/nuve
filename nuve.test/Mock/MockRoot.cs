using System.Collections.Generic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Test.Mock
{
    internal class MockRoot : Root
    {
        public MockRoot(string pos, string lexicalForm)
            : base(pos, lexicalForm, new HashSet<string>(), new List<OrthographyRule>())
        {
        }
    }
}