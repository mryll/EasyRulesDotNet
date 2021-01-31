namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Core;
    using FluentAssertions;
    using Xunit;

    public class BasicRuleTests : AbstractTest
    {
        [Fact]
        public void Basic_rule_evaluate_should_return_false()
        {
            BasicRule basicRule = new BasicRule();
            basicRule.Evaluate(Facts).Should().BeFalse();
        }
    }
}