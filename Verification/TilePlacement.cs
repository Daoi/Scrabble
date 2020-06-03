using Scrabble.Game_Modeling;
using System.Windows.Forms;

namespace Scrabble.Verification
{
    class TilePlacement
    {
        const int maxX = 14;
        const int maxY = 14;
        public static bool CheckAdjacent(int x, int y, Button[,] board)
        {
            if (string.Equals(board[x, y].Text, "*")) 
                return true;

            return (x - 1 >= 0 && CheckForValidTile(x - 1, y, board)) ||
                   (x + 1 <= maxX && CheckForValidTile(x + 1, y, board)) ||
                   (y - 1 >= 0 && CheckForValidTile(x, y - 1, board)) ||
                   (y + 1 <= maxY && CheckForValidTile(x, y + 1, board));

        }

        //public static bool CheckAdjacent(int x, int y, InternalBoard ib)
        //{
        //    if (CheckForTurnPlacement(x, y, ib))
        //        return true;

        //    return (x - 1 >= 0 && CheckForTurnPlacement(x - 1, y, ib)) ||
        //           (x + 1 <= maxX && CheckForTurnPlacement(x + 1, y, ib)) ||
        //           (y - 1 >= 0 && CheckForTurnPlacement(x, y - 1, ib)) ||
        //           (y + 1 <= maxY && CheckForTurnPlacement(x, y + 1, ib));

        //}

        private static bool CheckForValidTile(int x, int y, Button[,] board)
        {
            return (!string.IsNullOrEmpty(board[x, y].Text) && board[x, y].Text.Length == 1 && board[x, y].Text != "*");
        }

        public static bool CheckForTurnPlacement(int pos, InternalBoard ib)
        {
            LetterTile lt = (LetterTile)ib.Board[pos];
            return lt.PlacedThisTurn;
        }
    }
}
