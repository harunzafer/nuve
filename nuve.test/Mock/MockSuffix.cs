using System.Collections.Generic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Test.Mock
{
    internal class MockSuffix : Suffix
    {
        public MockSuffix(string id, string lexicalForm)
            : base(id, lexicalForm, MorphemeType.I, new HashSet<string>(), new List<OrthographyRule>())
        {
        }
    }
}