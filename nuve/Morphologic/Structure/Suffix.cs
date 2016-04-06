using System;
using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public class Suffix : Morpheme, IEquatable<Suffix>
    {
        public Suffix(
            string id,
            string lexicalForm,
            ISet<string> surfaces,
            MorphemeType type,
            ISet<string> labels,
            IList<OrthographyRule> rules)
            : base(lexicalForm, surfaces, type, labels, rules)
        {
            Id = id;
            GraphId = id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Suffix) obj);
        }

        public bool Equals(Suffix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }

        public override string Id { get; }
        public override string GraphId { get; }
    }
}