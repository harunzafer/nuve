using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NLPT.Distance
{
    public interface IDistance
    {
        double Measure(string s1, string s2);
    }
}
