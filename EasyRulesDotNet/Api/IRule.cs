namespace EasyRulesDotNet.Api
{
    public interface IRule
    {
        const string DefaultName = "rule";

        public string Name { get; set; }

        bool Evaluate(Facts facts);
        void Execute(Facts facts);
    }
}