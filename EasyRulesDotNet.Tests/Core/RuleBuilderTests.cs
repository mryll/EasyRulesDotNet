namespace EasyRulesDotNet.Tests.Core
{
    using EasyRulesDotNet.Api;
    using EasyRulesDotNet.Core;
    using FluentAssertions;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Xunit;

    public class RuleBuilderTests
    {
        private readonly Mock<IAction> _action1 = new();
        private readonly Mock<IAction> _action2 = new();
        private readonly Mock<ICondition> _condition = new();

        [Fact]
        public void Default_rule_creation_with_default_values()
        {
            IRule rule = new RuleBuilder().Build();

            rule.Name.Should().Be(IRule.DefaultName);
            rule.Should().BeOfType<DefaultRule>();
        }

        [Fact]
        public void Default_rule_creation_with_custom_values()
        {
            IRule rule = new RuleBuilder()
                .Name("myRule")
                .Description("myRuleDescription")
                .Priority(3)
                .When(_condition.Object)
                .Then(_action1.Object)
                .Then(_action2.Object)
                .Build();

            rule.Name.Should().Be("myRule");
            rule.Description.Should().Be("myRuleDescription");
            rule.Priority.Should().Be(3);
            rule.Should().BeOfType<DefaultRule>();
            rule.GetMemberValue("_condition").Should().BeSameAs(_condition.Object);
            rule.GetMemberValue("_actions").As<IList<IAction>>().Should()
                .ContainInOrder(_action1.Object, _action2.Object);
        }
    }

    /// <summary>
    ///     Extensions methos for using reflection to get / set member values
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        ///     Gets the public or private member using reflection.
        /// </summary>
        /// <param name="obj">The source target.</param>
        /// <param name="memberName">Name of the field or property.</param>
        /// <returns>the value of member</returns>
        public static object GetMemberValue(this object obj, string memberName)
        {
            MemberInfo memInf = GetMemberInfo(obj, memberName);

            if (memInf == null)
            {
                throw new Exception("memberName");
            }

            return memInf switch
            {
                PropertyInfo => memInf.As<PropertyInfo>().GetValue(obj, null),
                FieldInfo => memInf.As<FieldInfo>().GetValue(obj),
                _ => throw new Exception()
            };
        }

        /// <summary>
        ///     Gets the member info
        /// </summary>
        /// <param name="obj">source object</param>
        /// <param name="memberName">name of member</param>
        /// <returns>instanse of MemberInfo corresponsing to member</returns>
        private static MemberInfo GetMemberInfo(object obj, string memberName)
        {
            List<PropertyInfo> prps = new();

            prps.Add(obj.GetType().GetProperty(memberName,
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.FlattenHierarchy));
            prps = prps.Where(i => !ReferenceEquals(i, null)).ToList();
            if (prps.Count != 0)
            {
                return prps[0];
            }

            List<FieldInfo> flds = new();

            flds.Add(obj.GetType().GetField(memberName,
                BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.FlattenHierarchy));

            //to add more types of properties

            flds = flds.Where(i => !ReferenceEquals(i, null)).ToList();

            return flds.Count != 0 ? flds[0] : null;
        }
    }
}