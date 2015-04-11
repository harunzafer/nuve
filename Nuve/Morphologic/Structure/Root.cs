using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public class Root : Morpheme
    {
        /// <summary>
        ///     Yeni, immutable bir <see cref="Root" /> nesnesi oluşturur.
        /// </summary>
        /// <param name="id">Her bir "Root tipi" için biricik (unique) olan Id değeri </param>
        /// <param name="flags">Morfem'in tür bilgisini tutar. 2 ya da 3 karakterden oluşur.</param>
        /// <param name="lexicalForm">Morfemin sölük (lexicon) biçimi</param>
        /// <param name="rules">Morfem'in sahip olduğu Ortografi kurallarını tutar. 0 veya n tane olabilir.</param>
        private readonly string _surface; // yani sözlük hali

        public Root(string id, string lexicalForm, List<int> labels, List<OrthographyRule> rules)
            : base(id, lexicalForm, MorphemeType.Root, labels, rules)
        {
        }

        public Root(string id, string lexicalForm, List<int> labels, List<OrthographyRule> rules, string surface)
            : base(id, lexicalForm, MorphemeType.Root, labels, rules)
        {
            _surface = surface;
        }

        public string Surface
        {
            get { return _surface; }
        }


        public override string ToString()
        {
            return LexicalForm + " " + Id + " " + Rules.Count;
        }
    }
}