using System;
using System.Windows.Data;
using System.Globalization;

namespace Converters
{
    public class TextToIntConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to a string.
        /// </summary>
        /// <param name="value">The value produced by the binding source. This should be an integer.</param>
        /// <param name="targetType">The type of the binding target property. This parameter is not used.</param>
        /// <param name="parameter">The converter parameter to use. This parameter is not used.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value).ToString(culture);
        }

        /// <summary>
        /// Converts a value to an integer.
        /// </summary>
        /// <param name="value">The value produced by the binding source. This should be a string.</param>
        /// <param name="targetType">The type to convert to. This parameter is not used.</param>
        /// <param name="parameter">The converter parameter to use. This parameter is not used.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value.ToString();


            int parsedValue;
            if (int.TryParse(text, out parsedValue))
            {
                return parsedValue;
            }
            return 0;
        }
    }
}
