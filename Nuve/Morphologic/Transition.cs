using System;
using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class Transition : IEquatable<Transition>
    {
        private const string Delim = "+";
        public ConditionContainer Conditions { get; }
        public string Source { get; }
        public string Target { get; }
        public string Id { get; }
        public bool Empty { get; }

        public static string Key(string source, string target) => source + Delim + target;

        public Transition(string source, string target, ConditionContainer conditions, bool empty=false)
        {
            Source = source;
            Target = target;
            Conditions = conditions;
            Id = Source + Delim + Target;
            Empty = empty;
        }

        public bool Equals(Transition other)
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
            return Equals((Transition) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}