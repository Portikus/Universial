using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Universial.Core.Extensions.Unity;
using Universial.Test;

namespace Universial.Tests.Core.Extensions.Unity
{
    public class UnityExtensionsTest : TestBase<UnityContainer>
    {
        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            SystemUnderTest = new UnityContainer();
            SystemUnderTest.RegisterInstance<UnityExtensionsTest>();
            SystemUnderTest.RegisterInstance< TestBase ,UnityExtensionsTest >();
        }

        [Test]
        public void Test_if_RegisterInstanceOfT_returns_always_the_same_object()
        {
            var expected = SystemUnderTest.Resolve<UnityExtensionsTest>();
            Assert.That(()=>SystemUnderTest.Resolve<UnityExtensionsTest>(),Is.SameAs(expected));
        }

        [Test]
        public void Test_if_RegisterInstanceOfTBaseOfTType_returns_always_the_same_object()
        {
            var expected = SystemUnderTest.Resolve<TestBase>();
            Assert.That(() => SystemUnderTest.Resolve<TestBase>(), Is.SameAs(expected));
        }
    }
}