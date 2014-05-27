using System.Collections.Generic;

namespace Nuve.Orthographic
{
    static class CharSet
    {
         public static readonly IList<char> TurkishConsonants = new List<char>("bcçdfgğhjklmnprsştvyz".ToCharArray());
         public static readonly IList<char> TurkishVowels = new List<char>("aeıioöuü".ToCharArray());
    }
}
