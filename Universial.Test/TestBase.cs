using NUnit.Framework;

namespace Universial.Test
{
    public class TestBase
    {
        
    }

    public class TestBase<T> : TestBase
    {
        protected T SystemUnderTest;
        [SetUp]
        protected virtual void SetUp()
        {
            
        }
    }
}
