using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.WPFClient.Helpers
{
    static class SubstringHelper
    {
        public static string Truncate(this string value, int length)
            => (value != null && value.Length > length) ? value.Substring(0, length) : value;
    }
}
