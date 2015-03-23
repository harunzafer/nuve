using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    /// <summary>
    /// Bir kelime nesnesini temsil eder.
    /// </summary>
    public class Word : IEnumerable<Allomorph>, IEquatable<Word>
    {
        private readonly LinkedList<Allomorph> _allomorphs = new LinkedList<Allomorph>();
        private string _surface = string.Empty;


        /// <summary>
        /// Word[i] şeklinde kullanım için, i. Allomorfu döndürür.
        /// </summary>       
        public Allomorph this[int i]
        {
            get
            {                
                if (i < 0 || i >= _allomorphs.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                var node = _allomorphs.First;
                int counter = 0;               

                while (counter != i)
                {
                    node = node.Next;
                    counter++;
                }

                return node.Value;
            }
        }


        public int AllomorphCount
        {
            get { return _allomorphs.Count; }
        }

        // For IEnumerable<Allomorph>
        public IEnumerator<Allomorph> GetEnumerator()
        {
            return _allomorphs.GetEnumerator();
        }

        // For IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Kökü "root" olan yeni bir <see cref="Word"/> nesnesi oluşturur.
        /// </summary>
        /// <param name="root">Kelimenin kökü</param>
        public Word(Root root)
        {
            Root = root;
        }

        /// <summary>
        /// Bir kelimeden yeni bir kelime nesnesi oluşturur. Kopyalama (clone) amacıyla kullanılır.
        /// </summary>
        /// <param name="source">Kopyalanacak kelime</param>
        public Word(Word source)
        {
            Root = source.Root;
            IEnumerator<Allomorph> it = source._allomorphs.GetEnumerator();
            it.MoveNext(); //skip root
            while (it.MoveNext())
            {
                AddSuffix((Suffix) it.Current.Morpheme);
            }
        }

        public Root Root
        {
            get { return (Root) _allomorphs.First.Value.Morpheme; }
            set
            {
                var allomorph = new Allomorph(value);
                if (_allomorphs.Count != 0)
                {
                    _allomorphs.RemoveFirst();
                    ResetSurface();
                }
                _allomorphs.AddFirst(allomorph);
                allomorph.SetNode(_allomorphs.First);
            }
        }

        /// <summary>
        /// Tüm allomorph'ların yüzeylerini lexical (sözlük) biçimine geri alır.
        /// </summary>
        private void ResetSurface()
        {
            _surface = string.Empty;
            foreach (Allomorph allomorph in _allomorphs)
            {
                allomorph.ResetSurface();
            }
        }

        /// <summary>
        /// Kelimenin sonuna yeni bir ek ekler.
        /// </summary>
        /// <param name="suffix">Eklenecek ek.</param>
        public void AddSuffix(Suffix suffix)
        {
            var allomorph = new Allomorph(suffix);
            _allomorphs.AddLast(allomorph);
            allomorph.SetNode(_allomorphs.Last);
        }


        public void AddSuffixAfterRoot(Suffix suffix)
        {
            var allomorph = new Allomorph(suffix);
            _allomorphs.AddAfter(_allomorphs.First, allomorph);
            allomorph.SetNode(_allomorphs.First.Next);
            ResetSurface();
        }

        /// <summary>
        /// Kelimedeki en son eki kaldırır ve true döndürür. Kelimede ek yok ise false dönrürür
        /// </summary>
        public bool RemoveLastSuffix()
        {
            if (_allomorphs.Count <= 1)
                return false;

            _allomorphs.RemoveLast();
            ResetSurface();
            return true;
        }

        public bool HasSuffix(string suffixId)
        {
            return _allomorphs.Any(allomorph => allomorph.Morpheme.Id == suffixId);
        }

        public bool HasSuffixAt(string suffixId, int i)
        {
            return _allomorphs.Count > i && this[i].Morpheme.Id == suffixId;
        }

        public bool LastSuffixEquals(string suffixId)
        {
            return Last.Morpheme.Id == suffixId;
        }

        public Allomorph Last
        {
            get { return _allomorphs.Last.Value; }
        }

        /// <summary>
        /// Kelimenin yüzey biçimi döndürülür.
        /// </summary>
        /// <returns></returns>
        public string GetSurface()
        {
            if (_surface != string.Empty)
                return _surface;
            GenerateSurface();
            return _surface;
        }

        public IList<string> GetSurfacesAfterEachPhase()
        {
            var surfaces = new List<string>();

            foreach (Phase phase in Enum.GetValues(typeof(Phase)))
            {
                ProcessRulesOnAllomorphs(phase);
                surfaces.Add(ConcatAllomorphSurfaces());    
            }

            return surfaces;
        }

        /// <summary>
        /// Önce sol sonra sağ ortografik kurallar işletilerek kelimenin yüzeyi biçimi oluşturulur.
        /// </summary>
        private void GenerateSurface()
        {            
            foreach (Phase phase in Enum.GetValues(typeof(Phase)))
            {
                ProcessRulesOnAllomorphs(phase);
            }

            _surface = ConcatAllomorphSurfaces();
        }

        private string ConcatAllomorphSurfaces()
        {
            var sb = new StringBuilder("");
            foreach (Allomorph allomorph in _allomorphs)
            {
                sb.Append(allomorph.Surface);
            }

            return sb.ToString();
        }

        private void ProcessRulesOnAllomorphs(Phase phase)
        {
            foreach (Allomorph allomorph in _allomorphs)
            {
                allomorph.ProcessRules(phase);
            }
        }

        public string GetLexicalForm()
        {
            var sb = new StringBuilder();
            foreach (Allomorph allomorph in _allomorphs)
            {
                sb.Append(allomorph.Morpheme.LexicalForm).Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        public IList<string> GetMorphemeIds()
        {
            var ids = _allomorphs.Select(allomorph => allomorph.Morpheme.Id).ToList();
            //ids.RemoveAt(0);
            ids.Insert(0, Root.LexicalForm);
            return ids;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Allomorph allomorph in _allomorphs)
            {
                sb.Append(allomorph.Morpheme.TaggedForm).Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Word) obj);
        }

        public bool Equals(Word other)
        {

            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            int hashcode = 0;

            foreach (var allomorph in _allomorphs)
            {
                hashcode += allomorph.Morpheme.GetHashCode();
            }

            return hashcode;
        }


        public string Analysis
        {
            get { return ToString(); }
        }

        /// <summary>
        /// Returns a new word object which contains only derivational suffixes of this word.
        /// </summary>
        /// <returns>The stem of this word as a new word object</returns>
        public Word GetStem()
        {
            var stem = new Word(Root);

            foreach (var allomorph in _allomorphs)
            {
                if (allomorph.Morpheme.Type == MorphemeType.D)
                {
                    stem.AddSuffix((Suffix) allomorph.Morpheme);
                }
                else if (allomorph.Morpheme.Type == MorphemeType.I)
                {
                    break;
                }
            }

            return stem;
        }
    }
}