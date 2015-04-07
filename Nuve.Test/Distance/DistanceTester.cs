using NUnit.Framework;
using Nuve.Distance;

namespace Nuve.Test.Distance
{
    class DistanceTester
    {
        static readonly object[] Source =
        {
            new object[] { "abc", "abc" },
            new object[] { "abcdef", "abc" },
            new object[] { "abc", "def" },
            new object[] { "abc", "" },
            new object[] { "", "" },
            new object[] { "", "def" },
        };

        [TestCaseSource("Source")]
        public void EuclideanDistanceTests(string s1, string s2)
        {
            var distanceTest = new DistanceTest(new EuclideanDistance());
            distanceTest.NotNegativeTest(s1, s2);
            distanceTest.ZeroDistanceTest(s1,s2);
            distanceTest.SymmetryTest(s1,s2);
            distanceTest.TriangeInequalityTest(s1, s2, "abc");
        }

        [TestCaseSource("Source")]
        public void LevenshteinDistanceTests(string s1, string s2)
        {
            var distanceTest = new DistanceTest(new LevenshteinDistance());
            distanceTest.NotNegativeTest(s1, s2);
            distanceTest.ZeroDistanceTest(s1, s2);
            distanceTest.SymmetryTest(s1, s2);
            distanceTest.TriangeInequalityTest(s1, s2, "abc");
        }

        [TestCaseSource("Source")]
        public void JaccardDistanceTests(string s1, string s2)
        {
            var distanceTest = new DistanceTest(new JaccardDistance());
            distanceTest.NotNegativeTest(s1, s2);
            distanceTest.ZeroDistanceTest(s1, s2);
            distanceTest.SymmetryTest(s1, s2);
            distanceTest.TriangeInequalityTest(s1, s2, "abc");
        }

        [TestCaseSource("Source")]
        public void HammingDistanceTests(string s1, string s2)
        {
            var distanceTest = new DistanceTest(new HammingDistance());
            distanceTest.NotNegativeTest(s1, s2);
            distanceTest.ZeroDistanceTest(s1, s2);
            distanceTest.SymmetryTest(s1, s2);
            distanceTest.TriangeInequalityTest(s1, s2, "abc");
        }
    }
}
