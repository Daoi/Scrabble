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
        int tileScore { get; set; }
        bool isBlankTile { get; set; } = false;
        int boardPosition;

    public LetterTile(string letter, int scoreValue)
        {
            if (letter.Equals(" "))
                isBlankTile = true;
            boardPosition = -1;
            tileLetter = letter;
            tileScore = scoreValue;
            base.Text = tileLetter;
        }
        public LetterTile()
        {
            boardPosition = -1;
            tileLetter = "";
            tileScore = 0;
            base.Text = tileLetter;
        }


        public void SetTIleLetter(string letter)
        {
            tileLetter = letter;
            base.Text = tileLetter;

        }

        public string GetTileLetter()
        {
            return tileLetter;
        }

        public void SetBoardPosition(int position)
        {
            boardPosition = position;
        }

        public int GetBoardPosition()
        {
            return boardPosition;
        }

         
    }
}
