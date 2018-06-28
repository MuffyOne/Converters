using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Converters
{
    public class TextToDoubleConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to a string.
        /// </summary>
        /// <param name="value">The value produced by the binding source. This should be a double.</param>
        /// <param name="targetType">The type of the binding target property. This parameter is not used.</param>
        /// <param name="parameter">The converter parameter to use. This parameter is not used.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value).ToString(culture);
        }
        /// <summary>
        /// Converts a value to a double.
        /// </summary>
        /// <param name="value">The value produced by the binding source. This should be a string.</param>
        /// <param name="targetType">The type to convert to. This parameter is not used.</param>
        /// <param name="parameter">The converter parameter to use. This parameter is not used.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value.ToString();
            return ParseDouble(text);
        }


        private double ParseDouble(string stringValue, double defaultValue = 0)
        {
            double parsedValue;
            bool stringWasParsed = TryParseDouble(stringValue, out parsedValue);

            return stringWasParsed ? parsedValue : defaultValue;
        }

        private bool TryParseDouble(string stringValue, out double value)
        {
            CultureInfo parsingCulture = DetermineStringCultureInfo(stringValue);
            return double.TryParse(stringValue, NumberStyles.Any, parsingCulture, out value);
        }

        
        private CultureInfo DetermineStringCultureInfo(string stringValue)
        {
            CultureInfo parsingCulture;
            if ((stringValue.Contains('.')) && stringValue.Contains(','))
            {
                int posPoint = stringValue.LastIndexOf(".", StringComparison.InvariantCulture);
                int posComma = stringValue.LastIndexOf(",", StringComparison.InvariantCulture);
                parsingCulture = posPoint > posComma ? CultureInfo.InvariantCulture : new CultureInfo("de-DE");

            }
            else
            {
                parsingCulture = (stringValue.Contains('.'))
                    ? CultureInfo.InvariantCulture
                    : new CultureInfo("de-DE");
            }
            return parsingCulture;
        }
    }
}
