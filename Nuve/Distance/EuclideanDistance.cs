using System;

namespace Nuve.Distance
{
    /// <summary>
    /// Burada her bir string'i bir nokta olarak kabul ediyoruz.
    /// Her bir karakteri de bir boyut olarak. Böylece her bir string n boyutlu bir vektör oluyor.
    /// Ancak gerçekte bir uzayın öklid uzayı olabilmesi için noktaların ortalamasını alabilmemiz gerekir.
    /// iki string'in ortalamasını alamadığımızdan aslında ortada bir öklid uzayı yok ve iki string arasındaki
    /// öklid uzaklığı pek de anlamlı değil!!! Ayrıca bir nokta vektöründeki boyutların tüm reel sayıları 
    /// değer olarak alabilmesi gerekir. Sadece integer'lardan oluşan bir vektörler de bir öklid uzayı
    /// oluşturmaz. Çünkü ortalaması tamsayı olmak zorunda değil!
    /// Euclidean Distance is actually can be defined r forms. 
    /// So the genereal formula is take the rth power of the difference of each dimension. Then take the rth root
    /// of the sum of the differeces. So the L-2 form is the most common one which is implemented here.
    /// L-1 form is the manhattan
    /// </summary>
 
    class EuclideanDistance : IDistance
    {
        public double Measure(string s1, string s2)
        {
            IDistance d = new HammingDistance();
            return Math.Sqrt(d.Measure(s1, s2));
        }
    }
}
