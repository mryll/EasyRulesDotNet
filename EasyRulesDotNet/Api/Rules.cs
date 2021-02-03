// unset

namespace EasyRulesDotNet.Api
{
    using System.Collections;
    using System.Collections.Generic;

    public class Rules : IEnumerable<IRule>
    {
        private readonly HashSet<IRule> _rules = new();

        public Rules(params IRule[] rules)
        {
            _rules.UnionWith(rules);
        }

        public IEnumerator<IRule> GetEnumerator()
        {
            return _rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Register one or more new rules.
        /// </summary>
        /// <param name="rules">Rules to register, must not be null</param>
        public void Register(params IRule[] rules)
        {
            foreach (var rule in rules)
            {
                _rules.Add(rule);
            }
        }
    }
}