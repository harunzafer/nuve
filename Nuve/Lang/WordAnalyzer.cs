using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nuve.Morphologic.Structure;

namespace Nuve.Lang
{
    public class WordAnalyzer
    {
        private readonly Language _lang;
        private readonly TraceSource _trace = new TraceSource("WordAnalyzer");

        /// <summary>
        ///     Creates a new word analyzer of the specified languge.
        /// </summary>
        /// <param name="source">Kopyalanacak kelime</param>
        [Obsolete("This constructor is deprecated and will not be available in near future, use of \"Language.Analyze(string token)\" instead.", false)]
        public WordAnalyzer(Language language)
        {
            _lang = language;
        }

        

        public IList<Word> Analyze(string token)
        {
            return Analyze(token, true, true);
        }

        internal IList<Word> Analyze(string token, bool checkOrthography, bool checkTransitionConditions)
        {
            var words = new List<Word>();
            IEnumerable<SurfaceMorphemePair<Root>> roots = FindPossibleRoots(token);
            foreach (var pair in roots)
            {
                GetPossibleWords(new Word(pair.Morpheme), token.Remove(0, pair.Surface.Length), words);
            }

            if (checkTransitionConditions)
            {
                EliminateByMorphotactics(words);
            }

            if (checkOrthography)
            {
                EliminateByOrtography(words, token);
            }

            return words.Distinct().ToList();
        }

        private IList<SurfaceMorphemePair<Root>> FindPossibleRoots(string token)
        {
            var pairs = new List<SurfaceMorphemePair<Root>>();
            for (var i = 0; i < token.Length; i++)
            {
                var prefix = token.Substring(0, i + 1);

                var morphemes = _lang.GetRootsHavingSurface(prefix);

                foreach (var morpheme in morphemes)
                {
                    pairs.Add(new SurfaceMorphemePair<Root>(prefix, morpheme));
                }
            }
            return pairs;
        }

        private IList<SurfaceMorphemePair<Suffix>> FindPossibleSuffixes(Morpheme last, string token)
        {
            var pairs = new List<SurfaceMorphemePair<Suffix>>();
            for (var i = 0; i < token.Length; i++)
            {
                var prefix = token.Substring(0, i + 1);

                var morphemes = _lang.GetSuffixesHavingSurface(prefix);

                foreach (var morpheme in morphemes)
                {
                    if (_lang.Morphotactics.HasTransition(last, morpheme))
                    {
                        pairs.Add(new SurfaceMorphemePair<Suffix>(prefix, morpheme));
                    }
                }
            }

            var empties = _lang.Morphotactics.GetMorphemesWithEmptyTransitions(last);
            foreach (var emptyId in empties)
            {
                pairs.Add(new SurfaceMorphemePair<Suffix>("", _lang.GetSuffix(emptyId)));
            }

            return pairs;
        }
       
        private void GetPossibleWords(Word word, string restOfWord, IList<Word> words)
        {
            var suffixes = FindPossibleSuffixes(word.Last.Morpheme, restOfWord);

            foreach (var suffix in suffixes)
            {
                word.AddSuffix(suffix.Morpheme);
                GetPossibleWords(word, restOfWord.Remove(0, suffix.Surface.Length), words);
                word.RemoveLastSuffix();
            }

            if (restOfWord.Length == 0 && _lang.Morphotactics.IsTerminal(word.Last.Morpheme))
            {
                var newPossibleWord = Word.CopyOf(word);
                words.Add(newPossibleWord);
            }
        }

        private void EliminateByMorphotactics(IList<Word> analyses)
        {
            for (var i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!_lang.Morphotactics.IsValid(analyses[i]))
                {
                    _trace.TraceEvent(TraceEventType.Verbose, 11, $"Eliminated by morph: {analyses[i]}");
                    analyses.RemoveAt(i);
                }
            }
        }


        private void EliminateByOrtography(IList<Word> analyses, string surface)
        {
            for (var i = analyses.Count - 1; i >= 0; i--) //Reverse for loop to remove element
            {
                if (!HasCorrectSurface(analyses[i], surface))
                {
                    _trace.TraceEvent(TraceEventType.Verbose, 11,
                        $"Eliminated by orthography. expected:{surface} actual:{analyses[i].GetSurface()} solution:{analyses[i]}");
                    analyses.RemoveAt(i);
                }
            }
        }

        private bool HasCorrectSurface(Word word, string surface)
        {
            return word.GetSurface() == surface;
        }

        private class SurfaceMorphemePair<T> where T : Morpheme
        {
            public SurfaceMorphemePair(string surface, T morpheme)
            {
                Surface = surface;
                Morpheme = morpheme;
            }

            public string Surface { get; }
            public T Morpheme { get; }
        }
    }
}