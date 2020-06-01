using System.Windows.Forms;

namespace Scrabble.Game_Mechanics.Scoring
{
    public static class CalculateScore
    {

        public static int CaluclatePlacedTileScore(Button boardTile, LetterTile letterTile)
        {
            int tileValue = LetterValues.getLetterValue(letterTile.Text);
            string tileType = boardTile.Text;
            if (tileType == "" || string.Equals(tileType, "*"))
            {
                return tileValue;
            }
            else if (string.Equals(tileType, "Double Letter Score"))
            {
                return tileValue * 2;
            }
            else if (string.Equals(tileType, "Triple Letter Score"))
            {
                return tileValue * 3;
            }
            
            return -1;
        }


    }
}
