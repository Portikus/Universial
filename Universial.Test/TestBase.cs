using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace Universial.Test
{
    public class TestBase
    {
        protected string TestDirectory = @".\TestDirectory";

        [SetUp]
        protected virtual void SetUp()
        {
            if (_needsTestDir())
            {
                Directory.CreateDirectory(TestDirectory);
            }
        }

        private bool _needsTestDir()
        {
            var methods = GetType().GetMethods();
            return methods.Select(method => method.CustomAttributes.Any(x => x.AttributeType == typeof (NeedsTestDirAttribute))).Any(et => et);
        }

        [TearDown]
        protected virtual void TearDown()
        {
            if (!_needsTestDir())
            {
                return;
            }
            DeleteDirecory(TestDirectory);
        }

        protected void DeleteDirecory(string testDirectory)
        {
            for (var i = 0; i < 10; i++)
            {
                if (Directory.Exists(testDirectory))
                {
                    Directory.Delete(testDirectory, true);
                }
                else
                {
                    return;
                }
                Thread.Sleep(2 ^ i);
            }
            //If this point is reached the TearDown could not delete the TestDirectory after some time
            throw new TimeoutException($"Could not delete the directory {testDirectory} after some tries");
        }
    }

    public class TestBase<T> : TestBase where T : class
    {
        protected T SystemUnderTest;
        [SetUp]
        protected override void SetUp()
        {

        }

    }
}
