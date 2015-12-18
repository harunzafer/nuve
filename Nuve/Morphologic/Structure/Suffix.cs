using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public class Suffix : Morpheme
    {
        /// <summary>
        ///     Yeni, immutable bir <see cref="Suffix" /> nesnesi oluşturur.
        /// </summary>
        /// <param name="id">Her bir Suffix için biricik (unique) olan Id değeri </param>
        /// <param name="type">Morfem'in tür bilgisini tutar. 2 ya da 3 karakterden oluşur.</param>
        /// <param name="lexicalForm">Morfemin sölük (lexicon) biçimi</param>
        /// <param name="rules">Morfem'in sahip olduğu Ortografi kurallarını tutar. 0 veya n tane olabilir.</param>
        public Suffix(string id, string lexicalForm, MorphemeType type, HashSet<string> labels, List<OrthographyRule> rules)
            : base(id, lexicalForm, type, labels, rules)
        {
        }
    }
}