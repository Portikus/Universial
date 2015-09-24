using Microsoft.Practices.Unity;

namespace Universial.Test.UnityTestHelper
{
    public class UnityTestBase<T> : TestBase<T>
    {
        protected UnityContainer Container;

        protected override void SetUp()
        {
            base.SetUp();
            Container = new UnityContainer();
        }
    }
}
