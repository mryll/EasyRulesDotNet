namespace EasyRulesDotNet.Api
{
    public interface IRulesEngine
    {
        void Fire(Rules rules, Facts facts);
    }
}