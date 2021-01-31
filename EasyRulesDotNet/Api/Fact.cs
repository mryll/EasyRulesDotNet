namespace EasyRulesDotNet.Api
{
    public class Fact<T>
    {
        public Fact(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public T Value { get; }

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