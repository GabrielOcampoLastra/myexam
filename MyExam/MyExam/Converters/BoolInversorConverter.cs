using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyExam.Converters
{
    /// <summary>
    /// Converter to inverse boolean
    /// </summary>
    public class BoolInversorConverter : IValueConverter
    {
        /// <summary>
        /// Inverts a bool
        /// </summary>
        /// <param name="value">Bool</param>
        /// <param name="targetType">System Type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }
        /// <summary>
        /// Convert if fails
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="targetType">System Type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
