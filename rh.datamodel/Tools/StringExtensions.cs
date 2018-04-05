using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RH.DataModel.Tools
{
    public static class StringExtensions
    {
        public static bool MyMatch(this string target, string value, bool quitSpacing = false)
        {
            if (string.IsNullOrWhiteSpace(target))
                return string.IsNullOrWhiteSpace(value);

            if (string.IsNullOrWhiteSpace(value))
                return true;

            return target.RemoveDiacritics(quitSpacing).ToLower().Contains(value.RemoveDiacritics().Trim().ToLower());
        }

        public static string RemoveDiacritics(this string text, bool quitSpacing = false)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark && (!quitSpacing || CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.SpaceSeparator))
              ).Normalize(NormalizationForm.FormC);
        }

        public static string ToUpperIfNotNull(this string target)
        {
            return target != null ? target.ToUpper() : null;
        }

        public static string ToLowerIfNotNull(this string target)
        {
            return target != null ? target.ToLower() : null;
        }
    }
}
