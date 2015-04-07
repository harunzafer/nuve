using NUnit.Framework;
using Nuve.Distance;

namespace Nuve.Test.Distance
{
    class DistanceTest
    {

        private IDistance d;

        public DistanceTest(IDistance d)
        {
            this.d = d;
        }

        public void NotNegativeTest(string s1, string s2)
        {
            double distance = d.Measure(s1, s2);
            Assert.GreaterOrEqual(distance, 0);
        }

        public void ZeroDistanceTest(string s1, string s2)
        {
            if (s1 == s2)
            {
                double distance = d.Measure(s1, s2);
                Assert.AreEqual(distance, 0);    
            }
        }

        public void SymmetryTest(string s1, string s2)
        {
            double distance1 = d.Measure(s1, s2);
            double distance2 = d.Measure(s2, s1);
            Assert.AreEqual(distance1, distance2);
        }

        public void TriangeInequalityTest(string s1, string s2, string s3)
        {
            double distance1 = d.Measure(s1, s2);
            double distance2 = d.Measure(s2, s3);
            double distance3 = d.Measure(s1, s3);
            Assert.LessOrEqual(distance3, distance1 + distance2);
        }

    }
}
