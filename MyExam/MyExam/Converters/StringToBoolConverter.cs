using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyExam.Converters
{
    /// <summary>
    /// Return true if text is empty
    /// </summary>
    public class StringToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Convert text to bool
        /// </summary>
        /// <param name="value">text</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">Additional parameters</param>
        /// <param name="culture">Culture Information</param>
        /// <returns>true if text is empty, false if not/returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace(value as string);
        }
        /// <summary>
        /// Reverse conversion
        /// </summary>
        /// <param name="value">Input object</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Additional parameters</param>
        /// <param name="culture">Culture Information</param>
        /// <returns>Input object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
