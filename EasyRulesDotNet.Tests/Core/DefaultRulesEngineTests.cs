// unset

namespace EasyRulesDotNet.Tests.Core
{
    using Moq;
    using Xunit;

    public class DefaultRulesEngineTests : AbstractTest
    {
        public DefaultRulesEngineTests()
        {
            Rule1.Setup(rule => rule.Name).Returns("r");
        }

        [Fact]
        public void When_conditions_is_true_then_action_should_be_executed()
        {
            Rule1.Setup(rule => rule.Evaluate(Facts)).Returns(true);
            Rules.Register(Rule1.Object);

            RulesEngine.Fire(Rules, Facts);

            Rule1.Verify(rule => rule.Execute(Facts), Times.Once);
        }

        [Fact]
        public void When_conditions_is_false_then_action_should_not_be_executed()
        {
            Rule1.Setup(rule => rule.Evaluate(Facts)).Returns(false);
            Rules.Register(Rule1.Object);

            RulesEngine.Fire(Rules, Facts);

            Rule1.Verify(rule => rule.Execute(Facts), Times.Never);
        }
    }
}