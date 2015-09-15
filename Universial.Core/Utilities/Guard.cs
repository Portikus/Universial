using System;
using System.Linq.Expressions;

namespace Universial.Core.Utilities
{
    /// <summary>
    /// Helper class which helps validating parameters
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws a ArgumentNullException if the passed parameter is null
        /// </summary>
        /// <param name="parameter">parameter passed as lambda expression</param>
        private static void _checkIfNotNull(Expression<Func<object>> parameter)
        {
            var exp = LambdaExpressionHelper.GetMemberExpressionOf(parameter);
            var name = exp.Member.Name;

            if (exp == null)
            {
                throw new ArgumentException("Lambda expression must be of the form ()=>parameter");
            }
            if (parameter.Compile()() == null)
            {
                throw new ArgumentNullException($"The parameter {name} is null");
            }
        }

        /// <summary>
        /// Throws a ArgumentNullException if the passed parameters are null
        /// </summary>
        /// <param name="parameters">parameter passed as lambda expression</param>
        public static void CheckIfNotNull(params Expression<Func<object>>[] parameters)
        {
            _checkIfNotNull(() => parameters);
            foreach (var property in parameters)
            {
                _checkIfNotNull(property);
            }
        }
    }
}
