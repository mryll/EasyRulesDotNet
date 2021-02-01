namespace EasyRulesDotNet.Api
{
    public interface ICondition
    {
        bool Evaluate(Facts facts);
    }
}