using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebsiteKernel
{
    public static class Guard
    {
        /// <summary>
        /// Determines whether [is not null] [the specified expr].
        /// </summary>
        /// <param name="expr">The expr.</param>
        public static void IsNotNull<T>(Expression<Func<T>> expr)
        {
            // expression value != default of T
            if (!expr.Compile()().Equals(default(T)))
                return;

            var param = (MemberExpression)expr.Body;
            throw new ArgumentNullException(param.Member.Name);
        }

        /// <summary>
        /// Determines whether [is correct type] [the specified o].
        /// </summary>
        /// <param name="o">The o.</param>
        public static void IsCorrectType<T>(object o)
        {
            var type = o.GetType();

            if (typeof(T).IsAssignableFrom(type))
                return;

            throw new InvalidCastException(type.Name);
        }
    }
}
