using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApp
{
    public class TempColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double temp = (double)value;

            if (temp >= 100) return Color.Red.MultiplyAlpha(.5);
            if (temp >= 90) return Color.OrangeRed.MultiplyAlpha(.5);
            if (temp >= 80) return Color.Orange.MultiplyAlpha(.5);
            if (temp >= 70) return Color.Yellow.MultiplyAlpha(.5);
            if (temp >= 60) return Color.Green.MultiplyAlpha(.5);
            if (temp >= 50) return Color.LightBlue.MultiplyAlpha(.5);
            if (temp >= 40) return Color.Blue.MultiplyAlpha(.5);
            return Color.DarkBlue.MultiplyAlpha(.5);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.White;
        }
    }
}


