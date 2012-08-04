using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebsiteKernel.Extensions
{
    public static class Strings
    {
        public static bool IsAlphaNumeric(this string strToCheck)
        {
            Regex objPattern = new Regex("[^a-zA-Z0-9]");
            return !objPattern.IsMatch(strToCheck);
        }

        public static bool ContainsEnum<T>(this string[] strArrayToCheck, T enumeration)
        {
            Guard.IsCorrectType<Enum>(enumeration);
            return strArrayToCheck.Contains(enumeration.ToString());
        }

        public static string TruncateAtWord(this string input, int length)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = input.LastIndexOf(" ", length);
            return string.Format("{0}...", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }
    }
}
