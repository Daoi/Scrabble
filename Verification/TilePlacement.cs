using System.Windows.Forms;

namespace Scrabble.Verification
{
    class TilePlacement
    {
        public static bool CheckAdjacent(int x, int y, int maxX, int maxY, Button[,] board)
        {
            if (string.Equals(board[x, y].Text, "*")) return true;

            return (x - 1 >= 0 && CheckForValidTile(x - 1, y, board)) ||
                   (x + 1 <= maxX && CheckForValidTile(x + 1, y, board)) ||
                   (y - 1 >= 0 && CheckForValidTile(x, y - 1, board)) ||
                   (y + 1 <= maxY && CheckForValidTile(x, y + 1, board));

        }

        private static bool CheckForValidTile(int x, int y, Button[,] board)
        {
            return (!string.IsNullOrEmpty(board[x, y].Text) && board[x, y].Text.Length == 1 && board[x, y].Text != "*");
        }
    }
}
