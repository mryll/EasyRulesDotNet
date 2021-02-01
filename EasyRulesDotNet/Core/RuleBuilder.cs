namespace EasyRulesDotNet.Core
{
    using Api;
    using System.Collections.Generic;

    public class RuleBuilder
    {
        private readonly IList<IAction> _actions = new List<IAction>();
        private ICondition _condition;
        private string _name = IRule.DefaultName;

        public IRule Build()
        {
            return new DefaultRule(_name, _condition, _actions);
        }

        public RuleBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public RuleBuilder When(ICondition condition)
        {
            _condition = condition;
            return this;
        }

        public RuleBuilder Then(IAction action)
        {
            _actions.Add(action);
            return this;
        }
    }
}