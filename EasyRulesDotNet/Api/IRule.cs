namespace EasyRulesDotNet.Api
{
    using System;

    /// <summary>
    ///     Abstraction for a rule that can be fired by a rules engine.
    ///     Rules are registered in a namespace of rule of type {@link Rules}
    ///     in which they must have a <strong>unique</strong> name.
    /// </summary>
    public interface IRule : IComparable<IRule>
    {
        /// <summary>
        ///     Default rule name.
        /// </summary>
        public const string DefaultName = "rule";

        /// <summary>
        ///     Default rule description.
        /// </summary>
        public const string DefaultDescription = "description";

        /// <summary>
        ///     Default rule priority.
        /// </summary>
        public const int DefaultPriority = Int32.MaxValue - 1;

        /// <summary>
        ///     Getter for rule name.
        /// </summary>
        public string Name => DefaultName;

        /// <summary>
        ///     Getter for rule description.
        /// </summary>
        public string? Description => DefaultDescription;

        /// <summary>
        ///     Getter for rule priority.
        /// </summary>
        public int Priority => DefaultPriority;

        /// <summary>
        ///     This method implements the rule's condition(s).
        ///     <strong>Implementations should handle any runtime exception and return true/false accordingly</strong>
        /// </summary>
        /// <param name="facts">A set of facts</param>
        /// <returns>True if the rule should be applied given the provided facts, false otherwise</returns>
        public bool Evaluate(Facts facts);

        /// <summary>
        ///     This method implements the rule's action(s).
        /// </summary>
        /// <param name="facts">A set of facts</param>
        /// <exception cref="Exception">Thrown if an exception occurs when performing action(s)</exception>
        public void Execute(Facts facts);
    }
}