using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nuve.Morphologic
{
    internal class Vertex : IEquatable<Vertex>
    {
        private readonly TraceSource _trace = new TraceSource("Vertex");

        public Vertex(string id, bool isTerminal)
        {
            Id = id;
            IsTerminal = isTerminal;
            _transitions = new Dictionary<string, Transition>();
            _emptyStringTransitions =  new Dictionary<string, Transition>();
        }

        public string Id { get; }
        public bool IsTerminal { get; }
        private readonly Dictionary<string, Transition> _transitions;
        private readonly Dictionary<string, Transition> _emptyStringTransitions;

        public bool Equals(Vertex other)
        {
            return Id.Equals(other.Id);
        }

        public IEnumerable<Transition> Transitions => _transitions.Values;

        public IEnumerable<Transition> EmptyStringTransitions => _emptyStringTransitions.Values;

        public bool TryGetTransition(string target, out Transition transition)
        {
            var key = Transition.Key(Id, target);

            return _transitions.TryGetValue(key, out transition);
        }

        public bool ContainsTransition(string target)
        {
            var key = Transition.Key(Id, target);

            return _transitions.ContainsKey(key);
        }

        public void AddTransition(Transition transition)
        {
            if (Id != transition.Source)
            {
                _trace.TraceEvent(TraceEventType.Error, 1,
                    $"Invalid transition, Vertex Source \"{Id}\" and Transition source \"{transition.Source}\" don't match!");
            }

            if (_transitions.ContainsKey(transition.Id))
            {
                _trace.TraceEvent(TraceEventType.Warning, 1,
                    $"Duplicate transition from {Id} to {transition.Target}");
                return;
            }

            _transitions.Add(transition.Id, transition);

            if (transition.Empty)
            {
                _emptyStringTransitions.Add(transition.Id, transition);
            }
        }
    }
}