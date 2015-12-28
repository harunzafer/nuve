using System.Collections.Generic;
using System.Linq;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public enum MorphemeType
    {
        I,
        D,
        O,
        Root
    }

    public abstract class Morpheme
    {
        protected readonly bool HasRule;

        protected Morpheme(string lexicalForm, MorphemeType type, HashSet<string> labels, List<OrthographyRule> rules)
        {
            LexicalForm = lexicalForm;
            Type = type;
            Labels = labels;
            Rules = rules;
            HasRule = Rules.Any();
        }

        internal HashSet<string> Labels { get; }

        internal List<OrthographyRule> Rules { get; }

        public abstract string Id { get; }

        public abstract string GraphId { get; }

        public string LexicalForm { get; }

        public MorphemeType Type { get; }

        internal bool HasLabel(string label)
        {
            return Labels.Contains(label);
        }

        internal bool ContainsRule(string id)
        {
            return Rules.Any(rule => rule.Id == id);
        }

        internal void ProcessRules(int phase, Allomorph allomorph)
        {
            if (HasRule)
                foreach (var rule in Rules)
                {
                    if (rule.Phase == phase)
                        rule.Process(allomorph);
                }
        }

        internal string DebugInfo => Id + " Rule count:" + Rules.Count;
    }
}