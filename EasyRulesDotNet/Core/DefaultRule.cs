namespace EasyRulesDotNet.Core
{
    using Api;
    using System.Collections.Generic;

    public class DefaultRule : BasicRule
    {
        private readonly IList<IAction> _actions;
        private readonly ICondition _condition;

        public DefaultRule(string name, ICondition condition, IList<IAction> actions) : base(name)
        {
            _condition = condition;
            _actions = actions;
        }

        public override bool Evaluate(Facts facts)
        {
            return _condition.Evaluate(facts);
        }

        public override void Execute(Facts facts)
        {
            foreach (var action in _actions)
            {
                action.Execute(facts);
            }
        }
    }
}