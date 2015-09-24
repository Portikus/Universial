using Microsoft.Practices.Unity;

namespace Universial.Core.Extensions.Unity
{
    public static class UnityExtensions
    {
        /// <summary>
        /// Registers a instance of the passed type <typeparamref name="T"/>. Uses a <see cref="ContainerControlledLifetimeManager"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        public static void RegisterInstance<T>(this UnityContainer container)
        {
            container.RegisterType<T>(container.Resolve<ContainerControlledLifetimeManager>());
        }

        /// <summary>
        /// Registers a instance of the passed type <typeparamref name="TType"/> and mappes it to the type <typeparamref name="TBase"/>.
        ///  Uses a <see cref="ContainerControlledLifetimeManager"/>
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TBase"></typeparam>
        /// <param name="container"></param>
        public static void RegisterInstance<TBase,TType>(this UnityContainer container) where TType : TBase
        {
            container.RegisterType<TBase,TType>(container.Resolve<ContainerControlledLifetimeManager>());
        }
    }
}
