using Helpers.Extensions;
using System;
using System.Globalization;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Helpers.Converters
{
    public class FormatStringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string inputDate = value as string;

            if (inputDate.Contains(","))
            {
                var arrayDate = inputDate.Split(',');
                return string.Format("{0} au {1}", arrayDate[0].ConvertDate(), arrayDate[1].ConvertDate()).ToLower();
            }

            return inputDate.ConvertDate().ToLower();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class FormatStringToDateDayConverter : IValueConverter
    {
        public string GetConvertedDate(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {
                DateTime parsedDate = default(DateTime);
                string pattern = "yyyy-MM-dd";
                if (DateTime.TryParseExact(inputDate, pattern, null, DateTimeStyles.None, out parsedDate))
                {
                    return parsedDate.ToString("dd");
                }
            }

            return inputDate;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string inputDate = value as string;

            if (inputDate.Contains(","))
            {
                var arrayDate = inputDate.Split(',');
                return GetConvertedDate(arrayDate[0]);
            }

            return GetConvertedDate(inputDate);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class FormatStringToDateMonthConverter : IValueConverter
    {
        public string GetConvertedDate(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {
                DateTime parsedDate = default(DateTime);
                string pattern = "yyyy-MM-dd";
                if (DateTime.TryParseExact(inputDate, pattern, null, DateTimeStyles.None, out parsedDate))
                {
                    return parsedDate.ToString("MM");
                }
            }

            return inputDate;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string inputDate = value as string;

            if (inputDate.Contains(","))
            {
                var arrayDate = inputDate.Split(',');
                return GetConvertedDate(arrayDate[0]);
            }

            return GetConvertedDate(inputDate);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
