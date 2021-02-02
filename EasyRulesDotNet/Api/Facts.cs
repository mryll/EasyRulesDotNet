namespace EasyRulesDotNet.Api
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     This class encapsulates a set of facts and represents a facts namespace.
    ///     Facts have unique names within a <code>Facts</code> object.
    /// </summary>
    public class Facts : Facts<Object>
    {
    }

    /// <summary>
    ///     This class encapsulates a set of facts and represents a facts namespace.
    ///     Facts have unique names within a <code>Facts</code> object.
    /// </summary>
    public class Facts<T> : IEnumerable<Fact<T>>
    {
        private readonly HashSet<Fact<T>> _facts = new();

        /// <summary>
        ///     Return an iterator on the set of facts. It is not intended to remove
        ///     facts using this iterator outside of the rules engine (aka other than doing it through rules)
        /// </summary>
        /// <returns>An iterator on the set of facts</returns>
        public IEnumerator<Fact<T>> GetEnumerator()
        {
            return _facts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Add a fact, replacing any fact with the same name.
        /// </summary>
        /// <param name="name">Name of the fact to add, must not be null</param>
        /// <param name="value">Value of the fact to add, must not be null</param>
        public void Put(string name, T value)
        {
            Fact<T>? fact = GetFact(name);
            if (fact != null)
            {
                Remove(fact);
            }

            Add(new Fact<T>(name, value));
        }

        /// <summary>
        ///     Remove a fact.
        /// </summary>
        /// <param name="fact">Fact to remove, must not be null</param>
        public void Remove(Fact<T> fact)
        {
            _facts.Remove(fact);
        }

        /// <summary>
        ///     Add a fact, replacing any fact with the same name.
        /// </summary>
        /// <param name="fact">Fact to add, must not be null</param>
        public void Add(Fact<T> fact)
        {
            Fact<T>? retrievedFact = GetFact(fact.Name);
            if (retrievedFact != null)
            {
                Remove(fact);
            }

            _facts.Add(fact);
        }

        /// <summary>
        ///     Get fact by name.
        /// </summary>
        /// <param name="factName">Name of the fact, must not be null</param>
        /// <returns>The fact having the given name, or null if there is no fact with the given name</returns>
        public Fact<T>? GetFact(string factName)
        {
            return _facts.FirstOrDefault(fact => fact.Name.Equals(factName));
        }

        /// <summary>
        ///     Clear facts.
        /// </summary>
        public void Clear()
        {
            _facts.Clear();
        }
    }
}