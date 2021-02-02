namespace EasyRulesDotNet.Core
{
    using Api;
    using System;

    /// <summary>
    ///     Basic rule implementation class that provides common methods.
    ///     You can extend this class and override <see cref="Evaluate" /> and <see cref="Execute" /> to provide rule
    ///     conditions and actions logic.
    /// </summary>
    public class BasicRule : IRule
    {
        /// <summary>
        ///     Create a new <see cref="BasicRule" />.
        /// </summary>
        public BasicRule() : this(IRule.DefaultName)
        {
        }

        /// <summary>
        ///     Create a new <see cref="BasicRule" />.
        /// </summary>
        /// <param name="name">Rule name</param>
        /// <param name="description">Rule description</param>
        /// <param name="priority">Rule priority</param>
        public BasicRule(
            string name,
            string description = IRule.DefaultName,
            int priority = IRule.DefaultPriority)
        {
            Name = name;
            Description = description;
            Priority = priority;
        }

        /// <summary>
        ///     Rule name
        /// </summary>
        public string Name { get; protected init; }

        /// <summary>
        ///     Rule description
        /// </summary>
        public string? Description { get; }

        /// <summary>
        ///     Rule priority
        /// </summary>
        public int Priority { get; }

        /// <inheritdoc cref="IRule.Evaluate" />
        public virtual bool Evaluate(Facts facts)
        {
            return false;
        }

        /// <inheritdoc cref="IRule.Execute" />
        public virtual void Execute(Facts facts)
        {
        }

        public int CompareTo(IRule? other)
        {
            if (other == null || Priority < other.Priority)
            {
                return -1;
            }

            return Priority > other.Priority ? 1 : String.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            int result = Name.GetHashCode();
            result = (31 * result) + (Description != null ? Description.GetHashCode() : 0);
            result = (31 * result) + Priority;
            return result;
        }


        public override bool Equals(object? o)
        {
            if (this == o)
            {
                return true;
            }

            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            BasicRule basicRule = (BasicRule)o;

            if (Priority != basicRule.Priority)
            {
                return false;
            }

            return Name.Equals(basicRule.Name) && Equals(Description, basicRule.Description);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}