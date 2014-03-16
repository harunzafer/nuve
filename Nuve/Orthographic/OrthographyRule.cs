using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic
{
    public enum RuleType { First, Previous, Next, Self, Default, None } ;

    public class OrthographyRule
    {
        private readonly string _id;
        private readonly RuleType _type;
        private readonly List<Transformation> _transformations;

        public RuleType Type { get { return _type; } }
        public string Id { get { return _id; } }

        public bool IsLeftRule { get { return _type == RuleType.Previous; } }
        public bool IsRightRule { get { return _type == RuleType.Next; } }
        public bool IsSelfRule { get { return _type == RuleType.Self; } }
        public bool IsDefaultRule { get { return _type == RuleType.Default; } }

        public OrthographyRule(string id, string direction, List<Transformation> transformations)
        {
            _id = id;
            if (!Enum.TryParse(direction, out _type))
            {
                throw new ArgumentException("Invalid Orthography Rule direction: " + direction);
            }
            _transformations = transformations;
        }

        public void Process(Allomorph allomorph)
        {
            foreach (Transformation transformation in _transformations)
            {
                if (transformation.Condition.IsTrue(allomorph))
                {
                    transformation.Transform(allomorph);
                    break;
                }
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
