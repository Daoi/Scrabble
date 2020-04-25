using System;
using System.Collections;
using System.Collections.Generic;
using Scrabble.Game_Mechanics;

namespace Scrabble
{
    public class Game
    {
        private static Random rand = new Random();


        private List<LetterTile> letterBag = new List<LetterTile>();

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
            {" ", 2 },
            {"None", 0 }
        };

        //Put bag generation somewhere else, probably game mechanics, maybe data handling?
        public Game()
        {
            foreach(string key in letterFrequency.Keys)
            {
                for (int i = 0; i < letterFrequency[key]; i++)
                    letterBag.Add(new LetterTile(key,getLetterValue(key)));
            }
        }
        
        public static int getLetterValue(string letter)
        {
            return LetterValues.getLetterValue(letter);
        }

        public string[] drawTiles(int count)
        {
           return DrawTiles.drawTiles(count, letterFrequency, letterBag);
        }
        //Add to game mechanics
        public void addTiles(string[] tiles)
        {
            foreach(string tile in tiles)
            {
                Increment(letterFrequency, tile);
                letterBag.Add(new LetterTile(tile,getLetterValue(tile)));
            }
        }

        public static void Increment<T>(Dictionary<T, int> dictionary, T key)
        {
            int count;
            dictionary.TryGetValue(key, out count);
            dictionary[key] = count + 1;
        }

        public static void Decrement<T>(Dictionary<T, int> dictionary, T key)
        {
            int count;
            dictionary.TryGetValue(key, out count);
            dictionary[key] = count - 1;
        }

    }
}