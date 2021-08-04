using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace KMWG_MVCApp_Profile
{
    public class SeoFriendlyLink
    {
        public static string FriendlyURLTitle(string pTitle)
        {
            pTitle = pTitle.Substring(0, 1).ToUpper() + pTitle.Substring(1).ToLower();
            pTitle = pTitle.Replace(" ", "-");
            pTitle = pTitle.Replace(".", "-");
            pTitle = pTitle.Replace("ı", "i");
            pTitle = pTitle.Replace("İ", "I");
            pTitle = pTitle.Replace("Ç", "C");
            pTitle = pTitle.Replace("Ç", "C");
            pTitle = pTitle.Replace("Ü", "U");
            pTitle = pTitle.Replace("ü", "u");
 
            pTitle = String.Join("", pTitle.Normalize(NormalizationForm.FormD) // türkçe karakterleri ingilizceye çevir.
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));

            pTitle = HttpUtility.UrlEncode(pTitle);
            return System.Text.RegularExpressions.Regex.Replace(pTitle, @"\%[0-9A-Fa-f]{2}", "");
        }
    }
}