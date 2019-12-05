using System;
using System.Globalization;
using System.Windows.Data;

namespace VetClinic.Wpf.ViewModel.Converters
{
    /// <summary>
    /// String to DateTime converter to validate dates using the specific date format
    /// 
    /// Adapted code from: 
    /// https://stackoverflow.com/questions/56621093/disable-datepicker-textbox-conversion-validation-on-focus-lost
    /// </summary>
    public class StringToDateTimeConverter : IValueConverter
    {
        private const string DateFormat = "yyyy-MM-dd";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dateTimeValue = (DateTime?)value;
            return dateTimeValue.HasValue ? 
                dateTimeValue.Value.ToString(DateFormat, CultureInfo.InvariantCulture) 
                : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value?.ToString();
            if (string.IsNullOrEmpty(stringValue))
                return default(DateTime?);

            var resultParse = DateTime.TryParseExact(stringValue, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTimeValue);

            return resultParse ? dateTimeValue : default(DateTime?);
        }
    }
}
