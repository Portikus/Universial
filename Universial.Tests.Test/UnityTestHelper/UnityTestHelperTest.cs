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

        public void TestMethod()
        {
            
        }
    }
}
