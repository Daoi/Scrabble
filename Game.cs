using System.Collections.Generic;

namespace Scrabble
{
    internal class Game
    {
        private Dictionary<string, int> letterValues = new Dictionary<string, int>()
        {
            {"A E I O U L N S T R", 1 },
            {"D G", 2 },
            {"B C M P", 3 },
            {"F H V W Y", 4 },
            {"K", 5 },
            {"J K", 8 },
            {"Q Z", 10 }
        };

        private Dictionary<string, int> letterFrequency = new Dictionary<string, int>()
        {
            {"A", 9 },
            {"B", 2 },
            {"C", 2 },
            {"D", 4 },
            {"E", 12 },
            {"F", 2 },
            {"G", 3 },
            {"H", 2 },
            {"I", 9 },
            {"J", 1 },
            {"K", 1 },
            {"L", 4 },
            {"M", 2 },
            {"N", 6 },
            {"O", 8 },
            {"P", 2 },
            {"Q", 1 },
            {"R", 6 },
            {"S", 4 },
            {"T", 6 },
            {"U", 4 },
            {"V", 2 },
            {"W", 2 },
            {"X", 1 },
            {"Y", 2 },
            {"Z", 1 },
            {"", 2 }
        };



    }
}