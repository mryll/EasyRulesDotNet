namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;

    public abstract class AbstractTest
    {
        protected readonly Facts<object> Facts;
        protected object Fact1, Fact2;
        protected Rules Rules;

        protected AbstractTest()
        {
            Facts = new Facts<object>();
            Facts.Put("fact1", Fact1);
            Facts.Put("fact1", Fact2);
        }
    }
}