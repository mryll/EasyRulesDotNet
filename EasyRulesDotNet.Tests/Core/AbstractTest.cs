namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using Moq;

    public abstract class AbstractTest
    {
        protected readonly Facts Facts;

        protected readonly Mock<IRule> Rule1 = new();
        protected readonly Rules Rules;

        protected readonly DefaultRulesEngine RulesEngine;
        protected object Fact1, Fact2;

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