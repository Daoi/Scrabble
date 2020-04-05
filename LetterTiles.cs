using System.Collections.Generic;

namespace Scrabble
{

    internal class LetterTiles
    {
        private static Dictionary<string, int> letterValues = new Dictionary<string, int>()
        {
            {"A E I O U L N S R", 1 },
            {"D G", 2 },
            {"B C M P", 3 },
            {"F H V W Y", 4 },
            {"K", 5 },
            {"J K", 8 },
            {"Q Z T", 10 }
        };


        public static int getLetterValue(string letter)
        {
            foreach (KeyValuePair<string, int> kvp in letterValues)
            {
                if (kvp.Key.Contains(letter))
                {
                    return kvp.Value;
                }
            }
            return -1;
        }

    }
}
