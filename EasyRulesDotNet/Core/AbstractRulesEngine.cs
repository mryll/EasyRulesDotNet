// unset

namespace EasyRulesDotNet.Core
{
    using Api;
    using System.Collections.Generic;

    /// <summary>
    ///     Base class for <see cref="IRulesEngine" /> implementations.
    /// </summary>
    public abstract class AbstractRulesEngine : IRulesEngine
    {
        public List<IRulesEngineListener> rulesEngineListeners;
        public List<IRuleListener> rulesListeners;


        public AbstractRulesEngine()
        {
            rulesEngineListeners = new List<IRulesEngineListener>();
        }

        // TODO: Use immutable collection
        /// <summary>
        ///     Return a unmodifiable list of the registered rule listeners.
        /// </summary>
        public IRuleListener[] RuleListeners => rulesListeners.ToArray();

        /// <summary>
        ///     Return an unmodifiable list of the registered rules engine listeners.
        /// </summary>
        public IRulesEngineListener[] RulesEngineListeners => rulesEngineListeners.ToArray();
    }
}