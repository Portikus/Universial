using NUnit.Framework;
using Universial.Test;

namespace Universial.Tests.Core.Extensions
{
    public class StringExtensionsTest : TestBase<string>
    {
        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            SystemUnderTest = "This is a test string";
        }

        [Test]
        public void Test_Contains_returns_true_if_the_string_contains_the_value()
        {
            Assert.That(() => SystemUnderTest.Contains("is a test"), Is.True);
        }

        [Test]
        public void Test_Contains_returns_false_if_the_string_contains_not_the_value()
        {
            Assert.That(() => SystemUnderTest.Contains("is a Test"), Is.False);
        }
    }
}
