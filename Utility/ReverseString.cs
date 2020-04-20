using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Utility
{
    public static class ReverseString
    {
        public static string Reverse(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
