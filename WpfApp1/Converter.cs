using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1
{
  public class BackGroundConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      double d = 0;
      if (value == null || !double.TryParse(value.ToString(), out d)) return 0;
      if (d > 0) return 1;
      if (d < 0) return -1;
      return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
