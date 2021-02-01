namespace EasyRulesDotNet.Api
{
    public interface IRulesEngineListener
    {
        void BeforeEvaluate();
        void AfterExecute();
    }
}