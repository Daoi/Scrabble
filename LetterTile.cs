using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    public class LetterTile:Button
    {
        string tileLetter { get; set; }
        string tileScore { get; set; }
        bool isBlankTile { get; set; } = false;
        int location { get; set; }

    public LetterTile(string letter, string score)
        {
            if (letter.Equals(" "))
                isBlankTile = true;

            tileLetter = letter;
            tileScore = score;
            base.Text = tileLetter;
        }

         
    }
}
