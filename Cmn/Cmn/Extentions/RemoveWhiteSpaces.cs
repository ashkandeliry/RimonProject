using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class EXT
    {
        public static string RemoveWhiteSpaces(this string input)
        {
            if (input != null)
            {
                return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            }
            else
            {
                return null;
            }
        }
    }
}
