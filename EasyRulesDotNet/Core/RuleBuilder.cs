namespace EasyRulesDotNet.Core
{
    using Api;
    using System;
    using System.Collections.Generic;

    public class RuleBuilder
    {
        private readonly IList<Action> _actions = new List<Action>();
        private ICondition _condition;
        private string _name = IRule.DefaultName;

        public IRule Build()
        {
            return new DefaultRule(_name);
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

        public RuleBuilder Then(Action action)
        {
            _actions.Add(action);
            return this;
        }
    }
}