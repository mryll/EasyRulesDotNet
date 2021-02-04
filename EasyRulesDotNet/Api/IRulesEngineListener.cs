// unset

namespace EasyRulesDotNet.Api
{
    /// <summary>
    ///     A listener for rules engine execution events.
    /// </summary>
    public interface IRulesEngineListener
    {
        /// <summary>
        ///     Triggered before evaluating the rule set.
        ///     <strong>
        ///         When this listener is used with a {@link InferenceRulesEngine},
        ///         this method will be triggered before the evaluation of each candidate rule
        ///         set in each iteration.
        ///     </strong>
        /// </summary>
        /// <param name="rules">Rules to fire</param>
        /// <param name="facts">Facts present before firing rules</param>
        void BeforeEvaluate(Rules rules, Facts facts) { }

        /// <summary>
        ///     Triggered after executing the rule set
        ///     <strong>
        ///         When this listener is used with a {@link InferenceRulesEngine},
        ///         this method will be triggered after the execution of each candidate rule
        ///         set in each iteration.
        ///     </strong>
        /// </summary>
        /// <param name="rules">Rules fired</param>
        /// <param name="facts">Facts present before firing rules</param>
        void AfterExecute(Rules rules, Facts facts) { }
    }
}