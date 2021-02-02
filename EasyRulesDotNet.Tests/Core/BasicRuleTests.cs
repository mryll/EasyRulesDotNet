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
        public void Compare_to()
        {
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