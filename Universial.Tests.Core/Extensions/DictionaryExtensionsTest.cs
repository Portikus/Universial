using System.Collections.Generic;
using NUnit.Framework;
using Universial.Core.Extensions;
using Universial.Test;

namespace Universial.Tests.Core.Extensions
{
    public class DictionaryExtensionsTest : TestBase<IDictionary<int, int>>
    {
        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            SystemUnderTest = new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3}
            };
        }

        [Test]
        public void Test_GetOrDefault_returns_a_existing_value()
        {
            Assert.That(()=>SystemUnderTest.GetOrDefault(1),Is.EqualTo(1));
        }

        [Test]
        public void Test_GetOrDefault_returns_a_default_value()
        {
            Assert.That(() => SystemUnderTest.GetOrDefault(4), Is.EqualTo(0));
        }
    }
}