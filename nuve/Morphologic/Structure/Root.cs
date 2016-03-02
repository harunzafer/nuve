using System;
using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Morphologic.Structure
{
    public class Root : Morpheme, IEquatable<Root>
    {
        public Root(string pos, string lexicalForm, HashSet<string> labels, List<OrthographyRule> rules)
            : base(lexicalForm, MorphemeType.Root, labels, rules)
        {
            Id = lexicalForm + "/" + pos;
            GraphId = pos;
            Pos = pos;
        }

        public Root(string id, string lexicalForm, HashSet<string> labels, List<OrthographyRule> rules, string surface)
            : this(id, lexicalForm, labels, rules)
        {
            Surface = surface;
        }

        public string Pos { get; }

        public string Surface { get; }

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