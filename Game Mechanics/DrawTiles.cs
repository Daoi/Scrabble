using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Game_Mechanics
{
    public static class DrawTiles
    {
        private static Random rand = new Random();

        public static string[] drawTiles(int count, Dictionary<string,int> letterFrequency, List<LetterTile> letterBag)
        {
            string[] tiles = new string[count];
            for (int i = 0; i < count; i++)
            {
                string letter = "None";
                while (letterFrequency[letter] == 0 && letterBag.Count > 0)
                {
                    letter = letterBag[rand.Next(letterBag.Count)].GetTileLetter();
                    if (letter != "None" && letterFrequency[letter] > 0)
                    {
                        letterBag.Remove(letterBag.Find(lt => letter.Equals(lt.GetTileLetter())));
                    }
                }
                tiles[i] = letter;
                Game.Decrement(letterFrequency, letter);
            }
            return tiles;
        }
    }
}
