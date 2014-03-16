using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLPT.Distance
{
    //http://www.sequentix.de/gelquest/help/distance_measures.htm
    //Burada sıra öneml değil. string karşılaştırmadan ziyade
    // terimlerden oluşan vektörleri karşılaştırmada kullanmak daha mantıklı. Vektörler sparse olabilir. Bir sürü 0
    // ile uğraşmaya da gerek kalmaz
    // [a, b, c] vektörü ile [d, e, f] vektörü aynı kapıya çıkar böylece.
    abstract class BinarizedDistance : IDistance
    {
        private int a;//
        private int b;
        private int c;


        public abstract double Measure(string s1, string s2);
    
    }
}
