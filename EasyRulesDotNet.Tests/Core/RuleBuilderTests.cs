namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using FluentAssertions;
    using Xunit;

    public class RuleBuilderTests
    {
        [Fact]
        public void Default_rule_creation_with_default_values()
        {
            IRule rule = new RuleBuilder().Build();

            rule.Name.Should().Be(IRule.DefaultName);
            rule.Should().BeOfType<DefaultRule>();
        }

        [Fact]
        public void Default_rule_creation_with_custom_values()
        {
            IRule rule = new RuleBuilder().Name("myRule").Build();

            rule.Name.Should().Be("myRule");
            rule.Should().BeOfType<DefaultRule>();
        }
    }
}