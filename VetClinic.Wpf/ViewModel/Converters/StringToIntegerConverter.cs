using System;
using System.Globalization;
using System.Windows.Data;

namespace VetClinic.Wpf.ViewModel.Converters
{
    /// <summary>
    /// String to Integer converter to validate dates using the specific date format
    /// </summary>
    public class StringToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? dateTimeValue = (int?)value;
            return dateTimeValue.HasValue ? 
                dateTimeValue.Value.ToString() 
                : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value?.ToString();
            if (string.IsNullOrEmpty(stringValue))
                return default(int?);

            var resultParse = int.TryParse(stringValue, out int dateTimeValue);

            return resultParse ? dateTimeValue : default(int?);
        }
    }
}
