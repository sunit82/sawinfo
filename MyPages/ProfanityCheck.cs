using System;
using System.Collections.Generic;
using System.Web;

namespace MyPages
{
    public class ProfanityCheck
    {
        IList<string> censoredWords = new List<string> { 
            "gosh", "drat", "darn*", };

        public string CensorText(string text)
        {
            return "";
        }

    }
}
