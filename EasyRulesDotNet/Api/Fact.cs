namespace EasyRulesDotNet.Api
{
    /// <summary>
    ///     A class representing a named fact. Facts have unique names within a <see cref="Facts" /> instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Fact<T>
    {
        /// <summary>
        ///     Create a new fact.
        /// </summary>
        /// <param name="name">Name of the fact</param>
        /// <param name="value">Value of the fact</param>
        public Fact(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public T Value { get; }


        // The Facts API represents a namespace for facts where each fact has a unique name.
        // Hence, equals/hashcode are deliberately calculated only on the fact name.
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

            Fact<T> fact = (Fact<T>)o;
            return Name.Equals(fact.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}