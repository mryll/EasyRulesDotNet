namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using FluentAssertions;
    using Xunit;

    public class BasicRuleTests : AbstractTest
    {
        [Fact]
        public void Basic_rule_evaluate_should_return_false()
        {
            BasicRule basicRule = new();
            basicRule.Evaluate(Facts).Should().BeFalse();
        }

        [Fact]
        public void Compare_to_same_rule()
        {
            FirstRule rule1 = new();
            FirstRule rule2 = new();

            rule1.CompareTo(rule2).Should().Be(0);
            rule2.CompareTo(rule1).Should().Be(0);
        }

        [Fact]
        public void Compare_to_distinct_rule()
        {
            FirstRule rule1 = new();
            SecondRule rule2 = new();

            rule1.CompareTo(rule2).Should().Be(-1);
            rule2.CompareTo(rule1).Should().Be(1);
        }

        [Fact]
        public void Sort_sequence()
        {
            FirstRule rule1 = new();
            SecondRule rule2 = new();
            ThirdRule rule3 = new();

            Rules = new Rules(rule1, rule2, rule3);

            RulesEngine.Check(Rules, Facts);

            Rules.Should().ContainInOrder(rule1, rule2, rule3);
        }

        [Fact]
        public void To_string()
        {
            FirstRule rule1 = new();

            rule1.ToString().Should().BeSameAs("rule1");
        }

        private class FirstRule : BasicRule
        {
            public FirstRule()
            {
                Name = "rule1";
            }

            public override bool Evaluate(Facts facts)
            {
                return true;
            }
        }

        private class SecondRule : BasicRule
        {
            public SecondRule()
            {
                Name = "rule2";
            }

            public override bool Evaluate(Facts facts)
            {
                return true;
            }
        }

        private class ThirdRule : BasicRule
        {
            public ThirdRule()
            {
                Name = "rule3";
            }

            public override bool Evaluate(Facts facts)
            {
                return true;
            }
        }
    }
}