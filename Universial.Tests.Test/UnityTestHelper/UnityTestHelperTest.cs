using Microsoft.Practices.Unity;
using NUnit.Framework;
using Universial.Test.UnityTestHelper;

namespace Universial.Tests.Test.UnityTestHelper
{
    public class UnityTestHelperTest : UnityTestBase<UnityTestHelperTest>
    {
        [Test]
        public void Test_if_accessing_SystemUnderTest_throws_nothing()
        {
            Assert.That(()=>SystemUnderTest.TestMethod(),Throws.Nothing);
        }

        [Test]
        public void Test_if_accessing_SystemUnderTest_in_one_test_twice_does_not_return_a_new_object()
        {
            //Arrange 
            var first = SystemUnderTest;

            //Act
            var secound = SystemUnderTest;

            //Assert
            Assert.That(() => first, Is.SameAs(secound));
        }

        [Test]
        public void Test_if_SystemUnderTest_is_not_the_same_if_the_secound_is_new_resolved_from_container()
        {
            //Arrange 
            var first = SystemUnderTest;

            //Act
            var secound = Container.Resolve<UnityTestHelperTest>();

            //Assert
            Assert.That(() => first, Is.Not.SameAs(secound));
        }

        #region Test over to test methods
        private UnityTestHelperTest _firstTestInstance;

        [Test]
        public void Test_if_SystemUnderTest_is_a_new_object_in_a_new_test_Arrange()
        {
            //Arrange 
            _firstTestInstance = SystemUnderTest;
        }
        [Test]
        public void Test_if_SystemUnderTest_is_a_new_object_in_a_new_test_Assert()
        {
            //Act
            var secound = SystemUnderTest;

            //Assert
            Assert.That(() => _firstTestInstance, Is.Not.SameAs(secound));
        } 
        #endregion

        public void TestMethod()
        {
            
        }
    }
}
