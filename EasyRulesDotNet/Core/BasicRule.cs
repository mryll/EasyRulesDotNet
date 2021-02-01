namespace EasyRulesDotNet.Core
{
    using Api;

    public class BasicRule : IRule
    {
        protected BasicRule(string name)
        {
            Name = name;
        }

        public BasicRule() : this(IRule.DefaultName)
        {
        }

        public string Name { get; set; }

        public virtual bool Evaluate(Facts facts)
        {
            return false;
        }

        public virtual void Execute(Facts facts)
        {
        }
    }
}