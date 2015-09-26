using System.IO;
using NUnit.Framework;
using Universial.Test;

namespace Universial.Tests.Test
{
    public class TestBaseTests : TestBase
    {
        [Test]
        [NeedsTestDir]
        public void Test_if_TestBase_creates_test_directory_when_needed()
        {
            //Assert
            Assert.That(() => Directory.Exists(TestDirectory), Is.True);
        }

        [Test]
        [NeedsTestDir]
        public void Test_if_TestBase_deletes_the_directory_in_the_TearDown()
        {
            //Act
            TearDown();

            //Assert
            Assert.That(() => Directory.Exists(TestDirectory), Is.False);

        }

        [Test]
        [NeedsTestDir]
        public void Test_if_TestBase_deletes_the_directory_in_the_TearDown_when_the_directory_contains_sub_folder()
        {
            //Arrange 
            Directory.CreateDirectory(Path.Combine(TestDirectory, "SubFolder"));

            //Act
            TearDown();

            //Assert
            Assert.That(() => Directory.Exists(TestDirectory), Is.False);
        }
        public class TestBaseTestsNoAttribute : TestBase
        {
            [Test]
            public void Test_if_TestBase_creates_no_test_dir_when_no_attribute_is_set()
            {
                //Assert
                Assert.That(() => Directory.Exists(TestDirectory), Is.False);
            }
        }
    }
}
