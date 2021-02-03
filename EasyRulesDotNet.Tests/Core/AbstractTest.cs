namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using Moq;

    public abstract class AbstractTest
    {
        protected object Fact1, Fact2;
        protected Facts Facts;

        protected Mock<IRule> Rule1 = new();
        protected Rules Rules;

        protected DefaultRulesEngine RulesEngine;

        protected AbstractTest()
        {
            Facts = new Facts();
            Facts.Put("fact1", Fact1);
            Facts.Put("fact1", Fact2);
            Rules = new Rules();
            RulesEngine = new DefaultRulesEngine();
        }
    }
}