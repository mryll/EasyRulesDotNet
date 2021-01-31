namespace EasyRulesDotNet.Core
{
    using Api;

    public class DefaultRule : BasicRule
    {
        private readonly ICondition _condition;

        public DefaultRule(string name) : base(name)
        {
        }

        public DefaultRule(string name, ICondition condition) : base(name)
        {
            _condition = condition;
        }

        public override bool Evaluate<T>(Facts<T> facts)
        {
            return _condition.Evaluate(facts);
        }
    }
}