namespace EasyRulesDotNet.Api
{
    using System;
    using System.Collections.Generic;

    public interface IRulesEngine
    {
        /// <summary>
        ///     Return the list of registered rule listeners.
        /// </summary>
        public IRuleListener[] RuleListeners => Array.Empty<IRuleListener>();

        /// <summary>
        ///     Return the list of registered rules engine listeners.
        /// </summary>
        public IRulesEngineListener[] RulesEngineListeners => Array.Empty<IRulesEngineListener>();

        /// <summary>
        ///     Fire all registered rules on given facts.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="facts"></param>
        void Fire(Rules rules, Facts facts) { }

        /// <summary>
        ///     Check rules without firing them.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="facts"></param>
        /// <returns>A dictionary with the resutl of evaluation of each rule</returns>
        Dictionary<IRule, Boolean> Check(Rules rules, Facts facts)
        {
            return new();
        }
    }
}