using System;

namespace Universial.Core.Extensions
{
    public static class CastExtensions
    {
        public static TCast CastToType<TCast>(this object toCast) where TCast : class
        {
            var castedObject = toCast as TCast;
            if (castedObject != null)
            {
                return castedObject;
            }
            throw new ArgumentException($"The object {toCast} of the type {toCast.GetType()} could not be casted in the type {typeof(TCast)}");
        }
    }
}
