using Nuve.Condition;
using QuickGraph;

namespace Nuve.Morphologic
{
    class Transition<TVertex> : Edge<TVertex>
    {
        private readonly ConditionContainer _conditionContainer;
        public Transition(TVertex source, TVertex target, ConditionContainer conditionContainer)
        : base(source, target)
        {
            _conditionContainer = conditionContainer;
        }

        public Transition(TVertex source, TVertex target)
            : base(source, target)
        {
            _conditionContainer = ConditionContainer.EmptyContainer();
        }

        public ConditionContainer Conditions { get { return _conditionContainer; } }

    }
}
