namespace EasyRulesDotNet.Core
{
    using Api;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultRulesEngine : AbstractRulesEngine
    {
        public void Fire(Rules rules, Facts facts)
        {
            TriggerListenersBeforeRules(rules, facts);
            DoFire(rules, facts);
            TriggerListenersAfterRules(rules, facts);
        }

        private void TriggerListenersAfterRules(Rules rules, Facts facts)
        {
            rulesEngineListeners.ForEach(listener => listener.AfterExecute(rules, facts));
        }

        private void TriggerListenersBeforeRules(Rules rules, Facts facts)
        {
            rulesEngineListeners.ForEach(listener => listener.BeforeEvaluate(rules, facts));
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

        public Dictionary<IRule, Boolean> Check(Rules rules, Facts facts)
        {
            return DoCheck(rules, facts);
        }

        private Dictionary<IRule, bool> DoCheck(Rules rules, Facts facts)
        {
            return rules
                .Where(rule => ShouldBeEvaluated(rule, facts))
                .ToDictionary(rule => rule, rule => rule.Evaluate(facts));
        }

        private bool ShouldBeEvaluated(IRule rule, Facts facts)
        {
            // TODO: Implement listeners
            return true;
        }
    }
}