// unset

namespace EasyRulesDotNet.Api
{
    using System;
    using System.Data;

    /// <summary>
    ///     A listener for rule execution events
    /// </summary>
    public interface IRuleListener
    {
        /// <summary>
        ///     Triggered before the evaluation of a rule.
        /// </summary>
        /// <param name="rule">Rule being evaluated</param>
        /// <param name="facts"></param>
        /// <returns>True if the rule should be evaluated, false otherwise</returns>
        bool BeforeEvaluate(Rule rule, Facts facts) { return true; }

        /// <summary>
        ///     Triggered after the evaluation of a rule.
        /// </summary>
        /// <param name="rule">Rule that has been evaluated</param>
        /// <param name="facts"></param>
        /// <param name="evaluationResults">True if the rule evaluated to true, false otherwise</param>
        void AfterEvaluate(Rule rule, Facts facts, bool evaluationResults) { }

        /// <summary>
        ///     Triggered on condition evaluation error due to any runtime exception.
        /// </summary>
        /// <param name="rule">Rule that has been evaluated</param>
        /// <param name="facts">Facts known while evaluating the rule</param>
        /// <param name="exception">Exception that happened while attempting to evaluate the condition</param>
        void OnEvaluationError(Rule rule, Facts facts, Exception exception) { }

        /// <summary>
        ///     Triggered before the execution of a rule.
        /// </summary>
        /// <param name="rule">The current rule</param>
        /// <param name="facts">Known facts before executing the rule</param>
        void BeforeExecute(Rule rule, Facts facts) { }

        /// <summary>
        ///     Triggered after a rule has been executed successfully.
        /// </summary>
        /// <param name="rule">The current rule</param>
        /// <param name="facts">Facts after executing the rule</param>
        void OnSuccess(Rule rule, Facts facts) { }

        /// <summary>
        ///     Triggered after a rule has failed.
        /// </summary>
        /// <param name="rule">The current rule</param>
        /// <param name="facts">Facts known after executing the rule</param>
        /// <param name="exception">The exception thrown when attempting to execute the rule</param>
        void OnFailure(Rule rule, Facts facts, Exception exception) { }
    }
}