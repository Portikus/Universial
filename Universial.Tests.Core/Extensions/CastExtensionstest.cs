using System;
using NUnit.Framework;
using Universial.Core.Extensions;
using Universial.Test;

namespace Universial.Tests.Core.Extensions
{
    public class CastExtensionsTest : TestBase<object>
    {
        [Test]
        public void Test_if_CastTotype_casts_a_type()
        {
            SystemUnderTest = "TestObject";
            string casted = string.Empty;
            Assert.That(()=>casted = SystemUnderTest.CastToType<string>(),Throws.Nothing);
            Assert.That(casted,Is.SameAs(SystemUnderTest));
        }

        [Test]
        public void Test_if_CastTotype_throws_exception()
        {
            var testObject = "TestObject";
            Assert.That(() => testObject.CastToType<CastExtensionsTest>(), Throws.Exception);
        }
    }
}
