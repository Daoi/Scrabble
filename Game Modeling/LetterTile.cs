using Scrabble.Game_Mechanics;
using System;
using System.Windows.Forms;

namespace Scrabble
{
    public class LetterTile:Button
    {
        string tileLetter { get; set; }
        int tileScore { get; set; }
        bool isBlankTile { get; set; } = false;
        int boardPosition;
        public bool Exchange { get; set; } = false;
        bool placedThisTurn;

    public LetterTile(string letter, int scoreValue)
        {
            if (letter.Equals(" "))
                isBlankTile = true;
            boardPosition = -1;
            tileLetter = letter;
            tileScore = scoreValue;
            base.Text = tileLetter;
        }
        public LetterTile(Button btn)
        {
            if (btn.Text.Equals(" "))
                isBlankTile = true;
            boardPosition = int.Parse((string)btn.Tag);
            tileLetter = btn.Text;
            tileScore = LetterValues.getLetterValue(tileLetter);
        }

        public LetterTile()
        {
            boardPosition = -1;
            tileLetter = "";
            tileScore = 0;
            base.Text = tileLetter;
        }


        public void SetTileLetter(string letter)
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

        public int TileScore { get { return this.tileScore; } set { this.tileScore = value; } }


    }
}
