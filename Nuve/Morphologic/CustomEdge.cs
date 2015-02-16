using Nuve.Condition;
using QuickGraph;

namespace Nuve.Morphologic
{
    class CustomEdge<TVertex> : Edge<TVertex>
    {
        private readonly ConditionContainer _conditionContainer;
        public CustomEdge(TVertex source, TVertex target, ConditionContainer conditionContainer)
        : base(source, target)
        {
            _conditionContainer = conditionContainer;
        }

        public CustomEdge(TVertex source, TVertex target)
            : base(source, target)
        {
            _conditionContainer = ConditionContainer.EmptyContainer();
        }

        public ConditionContainer Conditions { get { return _conditionContainer; } }

    }
}
