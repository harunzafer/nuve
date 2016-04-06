using System;
using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public class Root : Morpheme, IEquatable<Root>
    {
        public Root(
            string pos, 
            string lexicalForm, 
            ISet<string> surfaces , 
            ISet<string> labels, 
            IList<OrthographyRule> rules)
            : base(lexicalForm, surfaces, MorphemeType.Root, labels, rules)
        {
            Id = lexicalForm + "/" + pos;
            GraphId = pos;
            Pos = pos;
        }

        public string Pos { get; }

        public override string Id { get; }

        public override string GraphId { get; }

        public bool Equals(Root other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Root) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}