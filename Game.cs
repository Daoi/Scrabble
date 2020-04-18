﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Scrabble
{
    public class Game
    {
        private static Random rand = new Random();

        private static Dictionary<string, int> letterValues = new Dictionary<string, int>()
        {
            {"A E I O U L N S T R", 1 },
            {"D G", 2 },
            {"B C M P", 3 },
            {"F H V W Y", 4 },
            {"K", 5 },
            {"J K", 8 },
            {"Q Z", 10 }
        };

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

        
        //Add to game mechanics
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
        //Add to game mechanics
        public string[] drawTiles(int count)
        {
            string[] tiles = new string[count];
            for (int i = 0; i < count; i++)
            {
                string letter = "None";
                while (letterFrequency[letter] == 0 && letterBag.Count > 0) {
                    letter = letterBag[rand.Next(letterBag.Count)].GetTileLetter();
                    if (letter != "None" && letterFrequency[letter] > 0)
                    {
                        letterBag.Remove(letterBag.Find(lt => letter.Equals(lt.GetTileLetter())));
                    }
                }
                tiles[i] = letter;
                Decrement(letterFrequency, letter);
            }
            return tiles;
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

        private static void Increment<T>(Dictionary<T, int> dictionary, T key)
        {
            int count;
            dictionary.TryGetValue(key, out count);
            dictionary[key] = count + 1;
        }

        private static void Decrement<T>(Dictionary<T, int> dictionary, T key)
        {
            int count;
            dictionary.TryGetValue(key, out count);
            dictionary[key] = count - 1;
        }

    }
}