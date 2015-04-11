namespace Nuve.Distance
{
    //http://www.sequentix.de/gelquest/help/distance_measures.htm
    //Burada sıra öneml değil. string karşılaştırmadan ziyade
    // terimlerden oluşan vektörleri karşılaştırmada kullanmak daha mantıklı. Vektörler sparse olabilir. Bir sürü 0
    // ile uğraşmaya da gerek kalmaz
    // [a, b, c] vektörü ile [d, e, f] vektörü aynı kapıya çıkar böylece.
    internal abstract class BinarizedDistance : IDistance
    {
        public abstract double Measure(string s1, string s2);
    }
}