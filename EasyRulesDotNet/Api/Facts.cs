namespace EasyRulesDotNet.Api
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Facts<T> : IEnumerable<Fact<T>>
    {
        private readonly HashSet<Fact<T>> _facts = new();

        public IEnumerator<Fact<T>> GetEnumerator()
        {
            return _facts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Put(string name, T value)
        {
            Fact<T>? fact = GetFact(name);
            if (fact != null)
            {
                Remove(fact);
            }

            Add(new Fact<T>(name, value));
        }

        public void Remove(Fact<T> fact)
        {
            _facts.Remove(fact);
        }

        public void Add(Fact<T> fact)
        {
            Fact<T>? retrievedFact = GetFact(fact.Name);
            if (retrievedFact != null)
            {
                Remove(fact);
            }

            _facts.Add(fact);
        }

        public Fact<T>? GetFact(string name)
        {
            return _facts.FirstOrDefault(fact => fact.Name.Equals(name));
        }
    }
}