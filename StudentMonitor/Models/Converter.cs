using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMonitor.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is int num)
            {
                if (num == 2) return new SolidColorBrush(Colors.Green);
                if (num == 1) return new SolidColorBrush(Colors.Yellow);
                else return new SolidColorBrush(Colors.Red);
            }
            if (value is float numf)
            {
                if (numf < 1) return new SolidColorBrush(Colors.Red);
                if (numf < 1.5) return new SolidColorBrush(Colors.Yellow);
                else return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.White);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
