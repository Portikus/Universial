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
        
        [Test]
        [NeedsTestDir]
        public void Test_if_CreateFileInTestDirectory_throws_no_exception_if_it_is_called_in_a_class_with_NeedsTestDirAttribute()
        {
            //Assert
            const string fileName = "Test.xml";
            Assert.That(() => CreateFileInTestDirectory(fileName), Throws.Nothing);
        }

        [Test]
        [NeedsTestDir]
        public void Test_if_CreateFileInTestDir_creates_file_in_TestDirectory()
        {
            //Arrange 
            const string fileName = "Test.xml";

            //Act
            CreateFileInTestDirectory(fileName);

            //Assert
            Assert.That(() => File.Exists(Path.Combine(TestDirectory, fileName)), Is.True);
        }

        [Test]
        [NeedsTestDir]
        public void Test_if_CreateFileInTestDir_creates_file_in_TestDirectory_with_subFolder()
        {
            //Arrange 
            const string fileName = "Test.xml";
            var combine = Path.Combine(TestDirectory,"A","B","C", fileName);

            //Act
            CreateFileInTestDirectory("A","B","C",fileName);

            //Assert
            Assert.That(() =>File.Exists(combine), Is.True);
        }

        public class TestBaseTestsNoAttribute : TestBase
        {
            [Test]
            public void Test_if_TestBase_creates_no_test_dir_when_no_attribute_is_set()
            {
                //Assert
                Assert.That(() => Directory.Exists(TestDirectory), Is.False);
            }

            [Test]
            public void Test_if_CreateFileInTestDirectory_throws_a_exception_if_it_is_called_in_a_class_without_NeedsTestDirAttribute()
            {
                //Assert
                const string fileName = "Test.xml";
                Assert.That(() => CreateFileInTestDirectory(fileName), Throws.Exception);
                Assert.That(() => File.Exists(Path.Combine(TestDirectory,fileName)), Is.False);
            }
        }
    }
}
