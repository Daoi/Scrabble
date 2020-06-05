using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
            StringBuilder sb = new StringBuilder();
            letterBag.ForEach(lt => sb.Append(lt.Text + " "));
            MessageBox.Show(sb.ToString());
            return tiles;
        }

        public static List<LetterTile> exchangeTiles(int count, List<LetterTile> letterBag)
        {
            List<LetterTile> newTiles = new List<LetterTile>();
            for(int i = 0; i < count; i++)
            {
                LetterTile tile = letterBag[rand.Next(letterBag.Count)];
                newTiles.Add(tile);
                letterBag.Remove(tile);

            }

            return newTiles;
        }
    }
}
