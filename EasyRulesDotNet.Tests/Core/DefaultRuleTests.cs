namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using Moq;
    using Xunit;

    public class DefaultRuleTests : AbstractTest
    {
        private readonly Mock<IAction> _action1 = new(MockBehavior.Strict);
        private readonly Mock<IAction> _action2 = new(MockBehavior.Strict);
        private readonly Mock<ICondition> _condition = new();

        [Fact]
        public void When_condition_is_true_then_actions_should_be_executed_in_order()
        {
            _condition.Setup(condition => condition.Evaluate(Facts)).Returns(true);
            MockSequence sequence = new();
            _action1.InSequence(sequence).Setup(action => action.Execute(Facts));
            _action2.InSequence(sequence).Setup(action => action.Execute(Facts));

            IRule rule = new RuleBuilder()
                .When(_condition.Object)
                .Then(_action1.Object)
                .Then(_action2.Object)
                .Build();

            Rules.Register(rule);

            RulesEngine.Fire(Rules, Facts);
        }

        [Fact]
        public void When_condition_is_false_then_actions_should_be_executed_in_order()
        {
            _condition.Setup(condition => condition.Evaluate(Facts)).Returns(false);

            IRule rule = new RuleBuilder()
                .When(_condition.Object)
                .Then(_action1.Object)
                .Then(_action2.Object)
                .Build();

            Rules.Register(rule);

            RulesEngine.Fire(Rules, Facts);

            _action1.Verify(action => action.Execute(Facts), Times.Never);
            _action2.Verify(action => action.Execute(Facts), Times.Never);
        }
    }
}