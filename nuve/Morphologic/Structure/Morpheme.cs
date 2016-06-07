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

        protected Morpheme(
            string lexicalForm,
            ISet<string> surfaces,
            MorphemeType type,
            ISet<string> labels,
            IList<OrthographyRule> rules)
        {
            LexicalForm = lexicalForm;
            Type = type;
            Labels = labels;
            Rules = rules;
            Surfaces = surfaces;
            HasRule = Rules.Any();
        }

        public string LexicalForm { get; }

        public ISet<string> Surfaces { get; }

        public MorphemeType Type { get; }

        public ISet<string> Labels { get; }

        public IEnumerable<OrthographyRule> Rules { get; }

        public abstract string Id { get; }

        public abstract string SequenceId { get; }
        

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

        public override string ToString()
        {
            return Id + " Rule count:" + Rules.Count();
        }

    }
}