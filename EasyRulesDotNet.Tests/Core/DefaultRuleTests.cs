namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using Moq;
    using System;
    using Xunit;

    public class DefaultRuleTests : AbstractTest
    {
        private readonly Mock<ICondition> _condition = new();
        private Action _action1, _action2;

        [Fact]
        public void When_condition_is_true_then_actions_should_be_executed_in_order()
        {
            _condition.Setup(condition => condition.Evaluate(Facts)).Returns(true);

            IRule rule = new RuleBuilder()
                .When(_condition.Object)
                .Then(_action1)
                .Then(_action2)
                .Build();

            Rules.Register(rule);
        }
    }
}