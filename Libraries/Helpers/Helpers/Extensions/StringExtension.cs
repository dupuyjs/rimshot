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

        public static string ConvertDate(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime parsedDate = default(DateTime);
                string pattern = "yyyy-MM-dd";
                if (DateTime.TryParseExact(str, pattern, null, DateTimeStyles.None, out parsedDate))
                {
                    return parsedDate.ToString("dddd dd MMMM yyyy").ToTitleCase();
                }
            }

            return str;
        }
    }
}
