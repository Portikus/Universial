using NUnit.Framework;
using Universial.Core.Utilities;

namespace Universial.Tests.Core.Utilities
{
    public class LambdaExpressionHelperTest
    {
        private string TestProperty = "";

        [Test]
        public void Test_GetMemberOf()
        {
            var member = LambdaExpressionHelper.GetMemberOf(() => TestProperty);
            
            Assert.AreEqual("TestProperty",member.Name);
        }
    }
}
