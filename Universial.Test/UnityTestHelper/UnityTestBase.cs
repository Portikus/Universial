using Microsoft.Practices.Unity;
using Universial.Core.Extensions.Unity;

namespace Universial.Test.UnityTestHelper
{
    public class UnityTestBase<T> : TestBase<T> where T : class
    {
        protected UnityContainer Container;

        private T _systemUnderTest;

        protected new T SystemUnderTest
        {
            get
            {
                if (_systemUnderTest == null)
                {
                    _systemUnderTest = Container.Resolve<T>();
                }
                return _systemUnderTest;
            }
        }

        protected override void SetUp()
        {
            base.SetUp();
            _systemUnderTest = null;
            Container = new UnityContainer();
            Container.RegisterType<T>();
        }
    }
}
