using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Universial.Test.UnityTestHelper
{
    public class UnityTestBase<T> : TestBase<T> where T : class
    {
        protected UnityContainer Container;

        private T _systemUnderTest;

        protected new T SystemUnderTest => _systemUnderTest ?? (_systemUnderTest = Container.Resolve<T>());

        [SetUp]
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
