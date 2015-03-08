using System;
using System.Collections.Generic;
using System.Text;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Test.Analysis
{
    public class TestGenerator
    {
        private static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language.Turkish);
        
        /// <summary>
        /// Kelimelerin sadece ilk çözümlerini kullanan bir ContainsAnalysis(token, analysis) testi üretir.
        /// Kelimelerden birinin çözümünün olmaması halinde exception verir.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="testName"></param>
        /// <returns></returns>
        public static string GenerateContainsAnalysisTest(string[] words, string testName)
        {
            var sb = new StringBuilder("");
            foreach (string word in words)
            {
                IList<Word> solutions = Analyzer.Analyze(word);
                try
                {
                    sb.AppendFormat("[TestCase(\"{0}\", \"{1}\"", word, solutions[0]);
                }
                catch (Exception)
                {
                    Console.WriteLine(word + " çözümlenemedi.");
                }
                
                sb.Append(")]").Append("\n");
            }
            sb.AppendFormat("public void {0}Test(string token, string analysis)", testName).AppendLine();
            sb.Append("{").AppendLine();
            sb.Append("\tTester.ContainsAnalysis(token, analysis);").AppendLine();
            sb.Append("}").AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Kelimenin tüm çözümlerinden partOfAnalysis stringini içeren çözümlerin kullanıldığı testi üretir.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="testName"></param>
        /// <param name="partOfAnalysis"></param>
        /// <returns></returns>
        public static string GenerateContainsAnalysesTest(string[] words, string testName, string partOfAnalysis)
        {
            var sb = new StringBuilder("");
            foreach (string word in words)
            {
                IList<Word> solutions = Analyzer.Analyze(word);
                sb.AppendFormat("[TestCase(\"{0}\", new [] {{", word);
                foreach (Word solution in solutions)
                {
                    if (solution.Analysis.Contains(partOfAnalysis))
                    {
                        sb.AppendFormat("\"{0}\", ", solution);
                    }
                    
                }
                sb.Append("})]").Append("\n");
            }
            sb.AppendFormat("public void {0}Test(string token, string[] analyses)", testName).AppendLine();
            sb.Append("{").AppendLine();
            sb.Append("\tTester.ContainsAnalyses(token, analyses);").AppendLine();
            sb.Append("}").AppendLine();
            return sb.ToString();
        }

        public static string GenerateAllAnalysesEqualTest(string[] words, string testName)
        {
            var sb = new StringBuilder("");
            foreach (string word in words)
            {
                IList<Word> solutions = Analyzer.Analyze(word);
                sb.AppendFormat("[TestCase(\"{0}\", new [] {{", word);
                foreach (Word solution in solutions)
                {
                        sb.AppendFormat("\"{0}\", ", solution);
                }
                sb.Append("})]").Append("\n");
            }
            sb.AppendFormat("public void {0}Test(string token, string[] analyses)", testName).AppendLine();
            sb.Append("{").AppendLine();
            sb.Append("\tTester.AllAnalysesEqual(token, analyses);").AppendLine();
            sb.Append("}").AppendLine();
            return sb.ToString();
        }

        public static string GenerateHasNoSolutionTest(string[] words, string testName)
        {
            var sb = new StringBuilder("");

            foreach (string word in words)
            {
                IList<Word> solutions = Analyzer.Analyze(word);
                if (solutions.Count != 0)
                {
                    throw new ArgumentException(word + " has a solution: " + solutions[0]);
                }

                sb.AppendFormat("[TestCase(\"{0}\"", word);
                sb.Append(")]").Append("\n");
            }
            sb.AppendFormat("public void {0}Test(string token)", testName).AppendLine();
            sb.Append("{").AppendLine();
            sb.Append("\tTester.HasNoAnalysis(token);").AppendLine();
            sb.Append("}").AppendLine();
            return sb.ToString();
        }

        public static string GenerateSolutionNotExistsTest(string[] words, string testName)
        {
            var sb = new StringBuilder("");

            foreach (string word in words)
            {
                IList<Word> solutions = Analyzer.Analyze(word);
                if (solutions.Count != 0)
                {
                    throw new ArgumentException(word + " has a solution: " + solutions[0]);
                }

                sb.AppendFormat("[TestCase(\"{0}\"", word);
                sb.Append(")]").Append("\n");
            }
            sb.AppendFormat("public void {0}Test(string token)", testName).AppendLine();
            sb.Append("{").AppendLine();
            sb.Append("\tTester.HasNoAnalysis(token);").AppendLine();
            sb.Append("}").AppendLine();
            return sb.ToString();
        }
    }
}