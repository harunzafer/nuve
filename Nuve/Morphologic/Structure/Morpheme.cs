using System.Collections.Generic;
using System.Linq;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public enum MorphemeType { I, D, O,  Root } ;
    
    /// <summary>
    /// Bir kelimenin en küçük yapı taşı olan morfemi temsil eden abstract class.<para/>
    /// Root ve Suffix sınıfları bu sınıftan türerler.<para/>
    /// Word sınıfı her biri içerisinde bir Morphmeme tutan bir Allomorph dizisi şeklinde düşünülür.<para/>
    /// Morpheme sınıfı immutable'dır.<para/>
    /// </summary>
    public abstract class Morpheme
    {
        private readonly List<int> _labels;
        internal bool HasLabel(int labelIndex)
        {
            return _labels.Any(label => labelIndex == label);
        }

        /// <summary>
        /// Morfem için biricik (unique) olan Id değeri<para/>
        /// </summary>
        /// <example>
        /// Morfem <see cref="Suffix"/> ise sistemde her suffix için biricik (unique) tanımlanmış olan id değerini 
        /// döndürür. Mesela çoğul eki için IC_COGUL_lAr gibi. <para/>
        /// Morfem <see cref="Root"/> ise Root'un tipini (root.Order) döndürür<para/>
        /// </example>
        public string Id{ get { return _id; }}
        private readonly string _id;
        
        /// <summary>
        /// Morfemin sölük (lexicon) biçimi<para/>
        /// Örneğin çoğul ekinin sözlük biçimi lAr şeklindedir.
        /// </summary>
        public string LexicalForm { get { return _lexicalForm; } }
        private readonly string _lexicalForm;

        public MorphemeType Type { get { return _type; } }
        private readonly MorphemeType _type;

        /// <summary>
        /// Morfemin sözlük biçimini id ile taglenmiş olarak döndürür.
        /// Mesela lAr/IC_COGUL_lAr gibi.
        /// </summary>
        public string TaggedForm
        {
            get { return LexicalForm + "/" + Id; }
        }

        /// <summary>
        /// Morfem'in sahip olduğu Ortografi kurallarını tutar. 0 veya n tane olabilir.<para/>
        /// </summary>
        internal List<OrthographyRule> Rules { get { return _rules; } }
        private readonly List<OrthographyRule> _rules;

        /// <summary>
        /// Yeni, immutable bir <see cref="Morpheme"/> nesnesi oluşturur.
        /// </summary>
        /// <param name="id"> </param>
        /// <param name="lexicalForm">Morfemin sölük (lexicon) biçimi</param>
        /// <param name="type">Morfem'in tür bilgisini tutar. 2 ya da 3 karakterden oluşur.</param>
        /// <param name="rules">Morfem'in sahip olduğu Ortografi kurallarını tutar. 0 veya n tane olabilir.</param>
        protected Morpheme(string id, string lexicalForm, MorphemeType type, List<int> labels, List<OrthographyRule> rules)
        {
            _id = id;
            _lexicalForm = lexicalForm;
            _type = type;
            _labels = labels;
            _rules = rules;
        }

        /// <summary>
        /// Morfem'in herhangi bir ortografi kuralı olup olmadığına bakar.
        /// </summary>
        /// <value>
        ///   <c>true</c> Eğer bir ya da daha fazla kural varsa; hiç kural yoksa, <c>false</c>.
        /// </value>
        protected bool HasRule
        {
            get { return Rules.Any(); }
        }

        /// <summary>
        /// Morfem'in herhangi bir ortografi kuralı olup olmadığına bakar.
        /// </summary>
        /// <value>
        ///   <c>true</c> Eğer bir ya da daha fazla kural varsa; hiç kural yoksa, <c>false</c>.
        /// </value>
        internal bool ContainsRule(string id)
        {
            foreach (var rule in _rules)
            {
                if (rule.Id == id)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Morfemden önce gelen morfemlerin yüzey biçiminden (leftSurface) etkilenen ortografik kuralları işletir.<para/>
        /// </summary>
        /// <param name="surface">Ortografik kurallar işletilerek değişime uğrayacak olan o anki yüzey biçimi</param>
        /// <param name="leftSurface">Bir önceki morfemin o anki yüzey biçimi</param>
        /// <returns>İşletilen kurallar neticesine değişen yüzeyin son hali</returns>
        internal void ProcessRules(RuleType ruleType, Allomorph allomorph)
        {
            if (HasRule)
                foreach (OrthographyRule rule in Rules)
                {
                    if (rule.Type == ruleType)
                        rule.Process(allomorph);
                }

        }

        
        ///// <summary>
        ///// Morfemden sonra gelen morfemlerin yüzey biçiminden (rightSurface) etkilenen ortografik kuralları işletir.<para/>
        ///// </summary>
        ///// <param name="surface">Ortografik kurallar işletilerek değişime uğrayacak olan o anki yüzey biçimi</param>
        ///// <param name="rightSurface">Bir sonraki morfemin o anki yüzey biçimi</param>
        ///// <returns>İşletilen kurallar neticesine değişen yüzeyin son hali</returns>
        //internal abstract string ProcessRightRules(string surface, SurfacePart rightSurface);


        ////Bu sadece kökler için geçerli bir kural tipi
        //internal abstract string ProcessSelfRules(string surface);

        public override string ToString()
        {
            return LexicalForm + " Rule count:" + Rules.Count;
        }
    }
}