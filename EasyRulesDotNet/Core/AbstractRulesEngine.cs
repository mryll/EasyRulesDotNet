// unset

namespace EasyRulesDotNet.Core
{
    using Api;

    public abstract class AbstractRulesEngine : IRulesEngine
    {
        public abstract void Fire(Rules rules, Facts facts);
    }
}