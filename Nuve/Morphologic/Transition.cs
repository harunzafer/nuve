using Nuve.Condition;
using QuickGraph;

namespace Nuve.Morphologic
{
    class Transition<TVertex> : Edge<TVertex>
    {
        private readonly ConditionContainer conditionContainer;
        public Transition(TVertex source, TVertex target, ConditionContainer conditionContainer)
        : base(source, target)
        {
            this.conditionContainer = conditionContainer;
        }

        public Transition(TVertex source, TVertex target)
            : base(source, target)
        {
            this.conditionContainer = ConditionContainer.EmptyContainer();
        }

        public ConditionContainer Conditions { get { return conditionContainer; } }

    }
}
