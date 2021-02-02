namespace EasyRulesDotNet.Core
{
    using Api;
    using System.Collections.Generic;

    public class RuleBuilder
    {
        private readonly IList<IAction> _actions = new List<IAction>();
        private ICondition _condition;
        private string _description = IRule.DefaultDescription;
        private string _name = IRule.DefaultName;
        private int _priority = IRule.DefaultPriority;

        public IRule Build()
        {
            return new DefaultRule(_name, _description, _priority, _condition, _actions);
        }

        public RuleBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public RuleBuilder Description(string description)
        {
            _description = description;
            return this;
        }

        public RuleBuilder Priority(int priority)
        {
            _priority = priority;
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