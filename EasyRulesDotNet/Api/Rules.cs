// unset

namespace EasyRulesDotNet.Api
{
    using System.Collections;
    using System.Collections.Generic;

    public class Rules : IEnumerable<IRule>
    {
        private readonly HashSet<IRule> _rules = new();

        public IEnumerator<IRule> GetEnumerator()
        {
            return _rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Register(params IRule[] rules)
        {
            foreach (var rule in rules)
            {
                _rules.Add(rule);
            }
        }
    }
}