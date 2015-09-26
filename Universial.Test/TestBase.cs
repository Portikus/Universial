using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace Universial.Test
{
    public abstract class TestBase
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

        #region Helper methods

        #region FileHandling

        /// <summary>
        /// Deletes a directory recursive. If the directory could not be deleted after 10 tries an exception will be thrown
        /// </summary>
        /// <param name="testDirectory"></param>
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

        /// <summary>
        /// Creates a file in the TestDirectory
        /// </summary>
        /// <param name="fileName"></param>
        protected void CreateFileInTestDirectory(string fileName)
        {
            Core.Utilities.Guard.CheckIfNotNull(()=>fileName);
            Assert.That(_needsTestDir,Is.True,$"The {nameof(NeedsTestDirAttribute)} is missing in the {GetType().Name} class.{Environment.NewLine}" +
                                                    $"Add the {nameof(NeedsTestDirAttribute)}");
            using(File.Create(Path.Combine(TestDirectory, fileName))){ }
        }

        /// <summary>
        /// Creates a file in the TestDirectory
        /// </summary>
        /// <param name="paths"></param>
        protected void CreateFileInTestDirectory(params string[] paths)
        {
            Core.Utilities.Guard.CheckIfNotNull(() => paths);
            Assert.That(_needsTestDir, Is.True, $"The {nameof(NeedsTestDirAttribute)} is missing in the {GetType().Name} class.{Environment.NewLine}" +
                                                    $"Add the {nameof(NeedsTestDirAttribute)}");
            var combinedPath = paths.Aggregate(TestDirectory, Path.Combine);
            var directory = Path.GetDirectoryName(combinedPath);
            Assert.That(()=>directory,Is.Not.Null,"Passed path could not be combined to a directory path");

            // ReSharper disable once AssignNullToNotNullAttribute
            Directory.CreateDirectory(directory);

            using (File.Create(combinedPath)) { }
        }

        #endregion


        #endregion

    }

    public abstract class TestBase<T> : TestBase where T : class
    {
        protected T SystemUnderTest;
    }
}
