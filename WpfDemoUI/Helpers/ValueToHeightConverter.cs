using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfDemoUI.Helpers
{
    public class ValueToHeightConverter : IValueConverter
    {
        public double MaxValue { get; set; } = 100;
        public double MaxHeight { get; set; } = 150;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double val)
            {
                return (val / MaxValue) * MaxHeight;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
