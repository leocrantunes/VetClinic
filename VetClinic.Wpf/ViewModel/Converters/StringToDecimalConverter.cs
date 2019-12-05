using System;
using System.Globalization;
using System.Windows.Data;

namespace VetClinic.Wpf.ViewModel.Converters
{
    /// <summary>
    /// String to Decimal converter to validate dates using the specific date format
    /// </summary>
    public class StringToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal? dateTimeValue = (decimal?)value;
            return dateTimeValue.HasValue ? 
                dateTimeValue.Value.ToString() 
                : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value?.ToString();
            if (string.IsNullOrEmpty(stringValue))
                return default(decimal?);

            var resultParse = decimal.TryParse(stringValue, out decimal dateTimeValue);

            return resultParse ? dateTimeValue : default(decimal?);
        }
    }
}
