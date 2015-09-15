using System;
using NUnit.Framework;
using Guard = Universial.Core.Utilities.Guard;

namespace Universial.Tests.Core.Utilities
{

    public class GuardTest
    {

        [Test]
        public void Test_with_null_parameter()
        {
            _test_exception_is_thrown(null);
        }

        [Test]
        public void Test_with_set_parameter()
        {
            _test_no_exception_is_thrown(new GuardTest());
        }

        [Test]
        public void Test_with_set_many_parameters_with_null()
        {
            _test_exception_is_thrown(new GuardTest(), null, new GuardTest());
        }

        [Test]
        public void Test_with_set_many_parameters_without_null()
        {
            Assert.DoesNotThrow(
                ()=> _test_exception_is_not_thrown(new GuardTest(), new GuardTest(), new GuardTest())
                );
        }
        
        #region Helper

        private void _test_no_exception_is_thrown(object a)
        {
            Assert.DoesNotThrow(() => Guard.CheckIfNotNull(() => a));
        }

        private void _test_exception_is_thrown(object a)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.CheckIfNotNull(() => a));
        }

        private void _test_exception_is_thrown(object a, object nullParameter, object c)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.CheckIfNotNull(() => a, () => nullParameter, () => c));

            try
            {
                Guard.CheckIfNotNull(() => a, () => nullParameter, () => c);
            }
            catch (ArgumentNullException e)
            {
                Assert.True(e.Message.Contains("nullParameter"));
            }
        }

        private void _test_exception_is_not_thrown(object a, object nullParameter, object c)
        {
            Guard.CheckIfNotNull(() => a, () => nullParameter, () => c);
        }
        #endregion
    }
}
