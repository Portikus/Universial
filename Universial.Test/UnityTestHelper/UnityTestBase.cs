using Microsoft.Practices.Unity;
using Universial.Core.Extensions.Unity;

namespace Universial.Test.UnityTestHelper
{
    public class UnityTestBase<T> : TestBase<T>
    {
        protected UnityContainer Container;

        protected new T SystemUnderTest => Container.Resolve<T>();

        protected override void SetUp()
        {
            base.SetUp();
            Container = new UnityContainer();
            Container.RegisterInstance<T>();
        }
    }
}
