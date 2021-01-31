namespace EasyRulesDotNet.Core
{
    using Api;

    public class BasicRule : IRule
    {
        public BasicRule(string name)
        {
            Name = name;
        }

        public BasicRule() : this(IRule.DefaultName)
        {
        }

        public string Name { get; set; }

        public virtual bool Evaluate<T>(Facts<T> facts)
        {
            return false;
        }
    }
}