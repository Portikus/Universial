using Microsoft.Practices.Unity;
using NUnit.Framework;
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

        [Test]
        public void Test_if_resolving_the_SystemUnderTest_throws_no_exceptions()
        {
            Assert.That(()=> SystemUnderTest,Throws.Nothing);
        }
    }
}
