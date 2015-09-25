using NUnit.Framework;

namespace Universial.Test
{
    public class TestBase
    {
        
    }

    public class TestBase<T> : TestBase where T : class
    {
        protected T SystemUnderTest;
        [SetUp]
        protected virtual void SetUp()
        {
            
        }
    }
}
