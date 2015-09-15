using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Universial.Core.Utilities
{
    /// <summary>
    /// Helper class for lambda expressions
    /// </summary>
    public static class LambdaExpressionHelper
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns>The member of the passed labda expression</returns>
        public static MemberInfo GetMemberOf<TProperty>(Expression<Func<TProperty>> property)
        {
            return GetMemberExpressionOf(property).Member;
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="property"></param>
        /// <returns>The memberexpression of the passed labda expression</returns>
        public static MemberExpression GetMemberExpressionOf<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = property as LambdaExpression;
            if (lambda == null)
            {
                throw new ArgumentException("Is not a valid LambdaExpression", "property");
            }

            MemberExpression memberExpression;

            var body = lambda.Body as UnaryExpression;
            if (body != null)
            {
                var unaryExpression = body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return memberExpression;
        }
    }
}
