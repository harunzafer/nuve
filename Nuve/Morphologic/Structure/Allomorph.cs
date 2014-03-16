using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Nuve.Condition;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    /// <summary>
    /// Allomorph'un kelime anlamı: Bir morpheme'in aldığı farklı biçimlerin her birine verilen ad.<para/>
    /// Morfemler bulundukları kelimeler içerisinde farklı yüzey biçimleri alırlar.<para/>
    /// Bir morfemin yüzey biçimi sahip olduğu ortografik kurallara ve kendisinin sağındaki ve solundaki morfemlere göre değişir<para/>
    /// </summary>
    [DebuggerDisplay("{morpheme.LexicalForm}=>{Surface}")]
    public class Allomorph
    {
        private LinkedListNode<Allomorph> _node;

        /// <summary>
        /// Her <see cref="Allomorph"/> nesnesi içerisinde bir Morpheme nesnesi barındırır.<para/>
        /// </summary>
        public Morpheme Morpheme
        {
            get { return _morpheme; }
        }
        private readonly Morpheme _morpheme;

        /// <summary>
        /// Allomorph'un yüzey biçimi
        /// </summary>
        public string Surface
        {
            get { return _surface; }
            set { _surface = value; }
        }
        private string _surface;

        /// <summary>
        /// Her <see cref="Allomorph"/> nesnesi içerisinde bir Morpheme nesnesi barındırır.<para/>
        /// </summary>
        /// <param name="morpheme">Allomorph'a kaynaklık eden Morpheme </param>
        public Allomorph(Morpheme morpheme)
        {
            _morpheme = morpheme;
            _surface = morpheme.LexicalForm;
        }

        /// <summary>
        /// Allomorph'lar bir linked list halinde bulunurlar Word sınıfı içerisinde<para/>
        /// Her allomorph içerisinde bulunduğu linkedlist node'una bir referans tutar.<para/>
        /// Bu sayede sağındaki ve solundaki morfemlerden haberdar olur<para/>
        /// </summary>
        /// <param name="node">linkedlist node'u</param>
        public void SetNode(LinkedListNode<Allomorph> node)
        {
            _node = node;
        }

        /// <summary>
        /// Soldaki yani bir önceki Allomorph'u döndürür.
        /// </summary>
        public Allomorph Previous
        {
            get { return _node.Previous != null ? _node.Previous.Value : null; }
        }


        public Allomorph First
        {
            get
            {
                Allomorph first = this;
                while (first.HasPrevious)
                {
                    first = first.Previous;
                }
                return first;
            }
        }

        public Allomorph Last
        {
            get
            {
                Allomorph last = this;
                while (last.HasNext)
                {
                    last = last.Next;
                }
                return last;
            }
        }

        /// <summary>
        /// Sağdaki yani bir sonraki Allomorph.
        /// </summary>
        public Allomorph Next
        {
            get { return _node.Next != null ? _node.Next.Value : null; }
        }


        /// <summary>
        /// Bu morfemden önce gelen bir morfem var mı? </para>
        /// Eğer morfem kelimenin kökü (Root) ise doğal olarak false dönecektir.
        /// </summary>
        /// <value>
        ///   <c>true</c> Morfemin solunda bir morfem varsa; yoksa, <c>false</c>.
        /// </value>
        public bool HasPrevious
        {
            get { return Previous != null; }
        }

        /// <summary>
        /// Bu morfemden sonra gelen bir morfem var mı? </para>
        /// Eğer morfem kelimenin son morfemi ise doğal olarak false dönecektir.
        /// </summary>
        /// <value>
        ///   <c>true</c> Morfemin sağında bir morfem varsa; yoksa, <c>false</c>.
        /// </value>
        public bool HasNext
        {
            get { return Next != null; }
        }

        public bool IsFirst
        {
            get { return HasPrevious; }
        }

        public bool IsLast
        {
            get { return HasNext; }
        }

        public string GetSurface(Position location)
        {
            if (location == Position.Next)
            {
                return GetNextSurface();
            }

            if (location == Position.Previous)
            {
                return GetPreviousSurface();
            }

            if (location == Position.Current || location == Position.Source)
            {
                return Surface;
            }

            throw new ArgumentException("Invalid neighbour surface direction to ");
        }



        /// <summary>
        /// Allomorph'un solunda kalan yüzeyi döndürür.
        /// </summary>
        /// <returns>sol/önceki yüzey</returns>
        protected string GetPreviousSurface()
        {
            var sb = new StringBuilder();
            Allomorph temp = Previous;
            sb.Append(Previous.Surface);
            while (temp.HasPrevious)
            {
                temp = temp.Previous;
                sb.Insert(0, temp.Surface);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Allomorph'un sonrasındaki yüzeyi döndürür.
        /// </summary>
        /// <returns>sağ/sonraki yüzey</returns>
        protected string GetNextSurface()
        {
            var sb = new StringBuilder();
            Allomorph temp = Next;
            sb.Append(Next.Surface);
            while (temp.HasNext)
            {
                temp = temp.Next;
                sb.Append(temp.Surface);
            }
            return sb.ToString();
        }

      
        /// <summary>
        /// Eğer morfemden sonra gelen bir morfem var ise ilk kuralları işlet
        /// </summary>
        private void ProcessFirstRules()
        {
            if (HasNext)
                _morpheme.ProcessRules(RuleType.First, this);
        }

        /// <summary>
        /// Eğer morfemden önce gelen bir morfem var ise Previous kuralları işlet
        /// </summary>
        private void ProcessPrevRules()
        {
            if (HasPrevious)
                _morpheme.ProcessRules(RuleType.Previous, this);
        }

        /// <summary>
        /// Eğer morfemden sonra gelen bir morfem var ise Next türündeki ortografik kuralları işlet.
        /// </summary>
        private void ProcessNextRules()
        {
            if (HasNext)
                _morpheme.ProcessRules(RuleType.Next, this);
        }

        /// <summary>
        /// Eğer morfemden sonra ek gelmiyorsa bu kural işletilir.
        /// Bu kuralın Condition'ı olmaz.
        /// </summary>
        private void ProcessSelfRules()
        {
            if (!HasNext)
                _morpheme.ProcessRules(RuleType.Self, this);
        }

        /// <summary>
        /// Diğer kuralların işletilmesinden sonra, son ve koşulsuz olarak bu kural işletilir.
        /// Genelde özel karakterleri silmek için kullanılır.
        /// </summary>
        private void ProcessDefaultRules()
        {
            _morpheme.ProcessRules(RuleType.Default, this);
        }


        internal void ProcessRules(RuleType ruleType)
        {
            switch (ruleType)
            {
                case RuleType.First:
                    ProcessFirstRules();
                    break;
                case RuleType.Previous:
                    ProcessPrevRules();
                    break;
                case RuleType.Next:
                    ProcessNextRules();
                    break;
                case RuleType.Self:
                    ProcessSelfRules();
                    break;
                case RuleType.Default:
                    ProcessDefaultRules();
                    break;
            }
        }


        /// <summary>
        /// Yüzeyi ilk sözlük biçimine geri al.
        /// </summary>
        internal void ResetSurface()
        {
            _surface = _morpheme.LexicalForm;
        }
    }
}