using System;
using System.Globalization;
using NUnit.Framework;
using Universial.Test;
using Universial.WPF.Converter;

namespace Universial.Tests.WPF.Converter
{
    public class DateTimeToOnlyDateConverterTest : TestBase<DateTimeToShortDateConverter>
    {
        protected override void SetUp()
        {
            base.SetUp();
            SystemUnderTest = new DateTimeToShortDateConverter();
        }

        [Test]
        public void Test_if_converter_converts()
        {
            //Arrange 
            var expected = "30.12.2012";
            var date = new DateTime(2012, 12, 30);

            //Act
            var actual = SystemUnderTest.Convert(date, typeof(string), null, CultureInfo.CurrentCulture);

            //Assert
            Assert.That(() => actual, Is.EqualTo(expected));
        }
    }
}
