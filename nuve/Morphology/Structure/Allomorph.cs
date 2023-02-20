using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Nuve.Condition;

namespace Nuve.Morphologic.Structure
{
    /// <summary>
    ///     Allomorph'un kelime anlamı: Bir morpheme'in aldığı farklı biçimlerin her birine verilen ad.
    ///     <para />
    ///     Morfemler bulundukları kelimeler içerisinde farklı yüzey biçimleri alırlar.
    ///     <para />
    ///     Bir morfemin yüzey biçimi sahip olduğu ortografik kurallara ve kendisinin sağındaki ve solundaki morfemlere göre
    ///     değişir
    ///     <para />
    /// </summary>
    [DebuggerDisplay("{Morpheme.LexicalForm}=>{Surface}")]
    public class Allomorph
    {
        private readonly Morpheme _morpheme;
        private LinkedListNode<Allomorph> _node;

        private string _surface;

        /// <summary>
        ///     Her <see cref="Allomorph" /> nesnesi içerisinde bir Morpheme nesnesi barındırır.
        ///     <para />
        /// </summary>
        /// <param name="morpheme">Allomorph'a kaynaklık eden Morpheme </param>
        public Allomorph(Morpheme morpheme)
        {
            _morpheme = morpheme;
            _surface = morpheme.LexicalForm;
        }

        /// <summary>
        ///     Her <see cref="Allomorph" /> nesnesi içerisinde bir Morpheme nesnesi barındırır.
        ///     <para />
        /// </summary>
        public Morpheme Morpheme => _morpheme;

        /// <summary>
        ///     Allomorph'un yüzey biçimi
        /// </summary>
        public string Surface
        {
            get { return _surface; }
            set { _surface = value; }
        }

        /// <summary>
        ///     Soldaki yani bir önceki Allomorph'u döndürür.
        /// </summary>
        public Allomorph Previous => _node.Previous?.Value;


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
        ///     Sağdaki yani bir sonraki Allomorph.
        /// </summary>
        public Allomorph Next => _node.Next?.Value;


        /// <summary>
        ///     Bu morfemden önce gelen bir morfem var mı? </para>
        ///     Eğer morfem kelimenin kökü (Root) ise doğal olarak false dönecektir.
        /// </summary>
        /// <value>
        ///     <c>true</c> Morfemin solunda bir morfem varsa; yoksa, <c>false</c>.
        /// </value>
        public bool HasPrevious => Previous != null;

        /// <summary>
        ///     Bu morfemden sonra gelen bir morfem var mı? </para>
        ///     Eğer morfem kelimenin son morfemi ise doğal olarak false dönecektir.
        /// </summary>
        /// <value>
        ///     <c>true</c> Morfemin sağında bir morfem varsa; yoksa, <c>false</c>.
        /// </value>
        public bool HasNext => Next != null;

        public bool IsFirst => HasPrevious;

        public bool IsLast => HasNext;

        /// <summary>
        ///     Allomorph'lar bir linked list halinde bulunurlar Word sınıfı içerisinde
        ///     <para />
        ///     Her allomorph içerisinde bulunduğu linkedlist node'una bir referans tutar.
        ///     <para />
        ///     Bu sayede sağındaki ve solundaki morfemlerden haberdar olur
        ///     <para />
        /// </summary>
        /// <param name="node">linkedlist node'u</param>
        public void SetNode(LinkedListNode<Allomorph> node)
        {
            _node = node;
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

            if (location == Position.This || location == Position.Source)
            {
                return Surface;
            }

            throw new ArgumentException("Invalid neighbour surface direction to ");
        }


        /// <summary>
        ///     Allomorph'un solunda kalan yüzeyi döndürür.
        /// </summary>
        /// <returns>sol/önceki yüzey</returns>
        protected string GetPreviousSurface()
        {
            var sb = new StringBuilder();
            Allomorph temp = this;
            while (temp.HasPrevious)
            {
                temp = temp.Previous;
                sb.Insert(0, temp.Surface);
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Allomorph'un sonrasındaki yüzeyi döndürür.
        /// </summary>
        /// <returns>sağ/sonraki yüzey</returns>
        protected string GetNextSurface()
        {
            var sb = new StringBuilder();
            Allomorph temp = this;
            while (temp.HasNext)
            {
                temp = temp.Next;
                sb.Append(temp.Surface);
            }
            return sb.ToString();
        }

        internal void ProcessRules(int phase)
        {
            _morpheme.ProcessRules(phase, this);
        }


        /// <summary>
        ///     Yüzeyi ilk sözlük biçimine geri al.
        /// </summary>
        internal void ResetSurface()
        {
            _surface = _morpheme.LexicalForm;
        }
    }
}