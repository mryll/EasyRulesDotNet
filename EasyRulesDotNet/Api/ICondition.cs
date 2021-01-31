namespace EasyRulesDotNet.Api
{
    public interface ICondition
    {
        bool Evaluate<T>(Facts<T> facts);
    }
}