using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Lang;
using Nuve.Morphologic.Format;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    /// <summary>
    ///     Represents a word that is analyzed into its morphemes.
    ///     A Word object is a sequence of Allomorph objects.
    ///     Each Allomorph contains one and only one Morpheme (Root or Suffix)
    ///     Morphemes are immutable objects created along with the cretation of a Language objects.
    /// </summary>
    public class Word : IEnumerable<Allomorph>, IEquatable<Word>
    {
        private readonly LinkedList<Allomorph> _allomorphs = new LinkedList<Allomorph>();
        private string _surface = string.Empty;

        /// <summary>
        ///     Creates a new Word object with the specified Root object.
        /// </summary>
        public Word(Root root)
        {
            Root = root;
        }

        /// <summary>
        ///     Returns the Allomorph at the specified index position.
        ///     Throws an IndexOutOfRangeException.
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
                var counter = 0;

                while (counter != i)
                {
                    node = node.Next;
                    counter++;
                }

                return node.Value;
            }
        }


        /// <summary>
        ///     Returns the number of Allomorphs (and Morphemes) in this Word.
        /// </summary>
        public int AllomorphCount => _allomorphs.Count;

        /// <summary>
        ///     Returns the Root of this Word
        /// </summary>
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
        ///     Returns the last Allomorph of this Word
        /// </summary>
        public Allomorph Last => _allomorphs.Last.Value;

        /// <summary>
        ///     Retuns the string representation of this Word
        /// </summary>
        public string Analysis => ToString();

        /// <summary>
        ///     Returns an Enumarator of the Allomorphs in this Word.
        /// </summary>
        public IEnumerator<Allomorph> GetEnumerator()
        {
            return _allomorphs.GetEnumerator();
        }

        /// <summary>
        ///     Returns an Enumarator of the Allomorphs in this Word.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(Word other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetHashCode() == other.GetHashCode();
        }


        /// <summary>
        ///     Creates a new copy of the specified word
        /// </summary>
        public static Word CopyOf(Word word)
        {
            var root = word.Root;
            var copy = new Word(root);

            IEnumerator<Allomorph> it = word._allomorphs.GetEnumerator();
            it.MoveNext(); //skip root
            while (it.MoveNext())
            {
                copy.AddSuffix((Suffix) it.Current.Morpheme);
            }

            return copy;
        }

        /// <summary>
        ///     Tüm allomorph'ların yüzeylerini lexical (sözlük) biçimine geri alır.
        /// </summary>
        private void ResetSurface()
        {
            _surface = string.Empty;
            foreach (var allomorph in _allomorphs)
            {
                allomorph.ResetSurface();
            }
        }

        /// <summary>
        ///     Appends the specified suffix to this word.
        /// </summary>
        public void AddSuffix(Suffix suffix)
        {
            var allomorph = new Allomorph(suffix);
            _allomorphs.AddLast(allomorph);
            allomorph.SetNode(_allomorphs.Last);
        }

        /// <summary>
        ///     Appends the specified suffix to this word and returns true if this operation is valid for the given language.
        ///     Otherwise does not append the suffix and returns false.
        /// </summary>
        //todo: Bu methodun language parametresi almasına gerek yok. Word sınıfına LanguageType özelliği eklendikten sonra
        public bool AddSuffix(Suffix suffix, Language language)
        {
            AddSuffix(suffix);
            if (!language.Morphotactics.IsValid(this))
            {
                RemoveLastSuffix();
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Adds the specified Suffix right after the Root of this Word
        /// </summary>
        public void AddSuffixAfterRoot(Suffix suffix)
        {
            var allomorph = new Allomorph(suffix);
            _allomorphs.AddAfter(_allomorphs.First, allomorph);
            allomorph.SetNode(_allomorphs.First.Next);
            ResetSurface();
        }

        /// <summary>
        ///     Removes the last Suffix containing Allomorph in this Word and returns true.
        ///     If this Word does not have any Allomorph containing a Suffix, returns false.
        /// </summary>
        public bool RemoveLastSuffix()
        {
            if (_allomorphs.Count <= 1)
                return false;

            _allomorphs.RemoveLast();
            ResetSurface();
            return true;
        }

        /// <summary>
        ///     Reports whether this Word has an Allomorph containing the Suffix with specified id.
        /// </summary>
        public bool HasSuffix(string suffixId)
        {
            return _allomorphs.Any(allomorph => allomorph.Morpheme.Id == suffixId);
        }

        /// <summary>
        ///     Reports whether this Word has an Allomorph containing the Suffix with specified id.
        /// </summary>
        public bool HasSuffixAt(string suffixId, int i)
        {
            return _allomorphs.Count > i && this[i].Morpheme.Id == suffixId;
        }

        /// <summary>
        ///     Reports whether this Word's last Allomorph contains the Suffix with specified id.
        /// </summary>
        public bool LastSuffixEquals(string suffixId)
        {
            return Last.Morpheme.Id == suffixId;
        }

        /// <summary>
        ///     Generates and returns the surface of this Word.
        /// </summary>
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

            for (var phase = 1; phase <= OrthographyRule.MaxPhaseNum; phase++)
            {
                ProcessRulesOnAllomorphs(phase);
                surfaces.Add(ConcatAllomorphSurfaces());
            }

            return surfaces;
        }

        /// <summary>
        ///     Önce sol sonra sağ ortografik kurallar işletilerek kelimenin yüzeyi biçimi oluşturulur.
        /// </summary>
        private void GenerateSurface()
        {
            for (var phase = 1; phase <= OrthographyRule.MaxPhaseNum; phase++)
            {
                ProcessRulesOnAllomorphs(phase);
            }

            _surface = ConcatAllomorphSurfaces();
        }

        private string ConcatAllomorphSurfaces()
        {
            var sb = new StringBuilder("");
            foreach (var allomorph in _allomorphs)
            {
                sb.Append(allomorph.Surface);
            }

            return sb.ToString();
        }

        private void ProcessRulesOnAllomorphs(int phase)
        {
            foreach (var allomorph in _allomorphs)
            {
                allomorph.ProcessRules(phase);
            }
        }
        
        //todo: WordFormatter
        public string GetLexicalForm()
        {
            var sb = new StringBuilder();
            foreach (var allomorph in _allomorphs)
            {
                sb.Append(allomorph.Morpheme.LexicalForm).Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        //todo: WordFormatter
        public IList<string> GetMorphemeIds()
        {
            var ids = _allomorphs.Select(allomorph => allomorph.Morpheme.Id).ToList();
            //ids.RemoveAt(0);
            ids.Insert(0, Root.LexicalForm);
            return ids;
        }

        /// <summary>
        ///     Retuns the string representation of this Word
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var allomorph in _allomorphs)
            {
                sb.Append(allomorph.Morpheme.Id).Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        ///     Retuns the string representation of this Word in specified format
        /// </summary>
        public string ToString(WordFormat format)
        {
            return format.Format(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Word) obj);
        }

        public override int GetHashCode()
        {
            var sum = 0;
            unchecked
            {
                foreach (var allomorph in _allomorphs)
                {
                    sum += allomorph.Morpheme.Id.GetHashCode();
                }
            }
            return sum;
        }


        /// <summary>
        ///     Returns a new Word which contains only derivational suffixes of this word.
        /// </summary>
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