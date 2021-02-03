// unset

namespace EasyRulesDotNet.Core
{
    using Api;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultRulesEngine : AbstractRulesEngine
    {
        public override void Fire(Rules rules, Facts facts)
        {
            // TriggerListenersBeforeRules(rules, facts);
            DoFire(rules, facts);
            // TriggerListenersAfterRules(rules, facts);
        }

        private void DoFire(Rules rules, Facts facts)
        {
            foreach (var rule in rules)
            {
                bool evaluationResult = rule.Evaluate(facts);

                if (evaluationResult)
                {
                    rule.Execute(facts);
                }
            }
        }

        public static Dictionary<IRule, Boolean> Check(Rules rules, Facts facts)
        {
            return DoCheck(rules, facts);
        }

        private static Dictionary<IRule, bool> DoCheck(Rules rules, Facts facts)
        {
            return rules
                .Where(rule => ShouldBeEvaluated(rule, facts))
                .ToDictionary(rule => rule, rule => rule.Evaluate(facts));
        }

        private static bool ShouldBeEvaluated(IRule rule, Facts facts)
        {
            // TODO: Implement listeners
            return true;
        }
    }
}