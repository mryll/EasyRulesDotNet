namespace EasyRulesDotNet.Tests.Api
{
    using EasyRulesDotNet.Api;
    using FluentAssertions;
    using Xunit;

    public class FactsTests
    {
        private readonly Facts<int> _facts = new();

        [Fact]
        public void Facts_must_have_unique_name()
        {
            _facts.Add(new Fact<int>("foo", 1));
            _facts.Add(new Fact<int>("foo", 2));

            _facts.Should().ContainSingle();
            Fact<int>? fact = _facts.GetFact("foo");
            fact?.Value.Should().Be(2);
        }

        [Fact]
        public void Facts_add()
        {
            Fact<int> fact1 = new Fact<int>("foo", 1);
            Fact<int> fact2 = new Fact<int>("bar", 2);

            _facts.Add(fact1);
            _facts.Add(fact2);

            _facts.Should().Contain(fact1);
            _facts.Should().Contain(fact2);
        }

        [Fact]
        public void Facts_put()
        {
            _facts.Put("foo", 1);
            _facts.Put("bar", 2);

            _facts.Should().Contain(new Fact<int>("foo", 1));
            _facts.Should().Contain(new Fact<int>("bar", 2));
        }

        [Fact]
        public void Facts_remove()
        {
            Fact<int> fact = new Fact<int>("foo", 1);
            _facts.Add(fact);
            _facts.Remove(fact);

            _facts.Should().BeEmpty();
        }
    }
}