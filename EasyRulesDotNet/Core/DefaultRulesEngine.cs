// unset

namespace EasyRulesDotNet.Core
{
    using Api;

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
    }
}