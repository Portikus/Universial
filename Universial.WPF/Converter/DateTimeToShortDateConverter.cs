using System;
using System.Globalization;
using System.Windows.Data;

namespace Universial.WPF.Converter
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeToShortDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
