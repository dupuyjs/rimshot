using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Extensions
{
    public static class StringExtension
    {
        public static string ToTitleCase(this String str)
        {
            if (str == null)
                return null;
            if (str.Length == 0)
                return str;

            StringBuilder result = new StringBuilder(str);
            result[0] = char.ToUpper(result[0]);
            for (int i = 1; i < result.Length; ++i)
            {
                if (char.IsWhiteSpace(result[i - 1]))
                    result[i] = char.ToUpper(result[i]);
                else
                    result[i] = char.ToLower(result[i]);
            }
            return result.ToString();
        }

        public static DateTime ConvertDate(this String str)
        {
            DateTime parsedDate = default(DateTime);

            if (!string.IsNullOrEmpty(str))
            {
                string pattern = "yyyy-MM-dd";
                if (DateTime.TryParseExact(str, pattern, null, DateTimeStyles.None, out parsedDate))
                {
                    return parsedDate;
                }
            }

            return parsedDate;
        }

        public static string WithSize(this String str, int width, int height)
        {
            return string.Format("{0}&w={1}&h={2}", str, width, height);
        }
        
    }
}
