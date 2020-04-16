using System.Text;
using System.Windows.Forms;

namespace Scrabble.Verification
{
    public static class BoardCheckerHorizontal
    {
        public static string CheckHorizontal(Button[,] btns, int tileIndex)
        {
            StringBuilder sb = new StringBuilder();
            int[] indicies = BoardHandler.getRowCol(tileIndex);
            int row = indicies[0];
            int col = indicies[1];
            int max = 14, min = 0;
            //Right
            for (int i = col; i < max; i++)
            {
                if (string.IsNullOrEmpty(btns[row, i].Text) || btns[row, i].Text.Length > 1)
                {
                    break;
                }
                else
                {
                    sb.Append(btns[row, i].Text);
                }
            }
            //Left
            for (int i = col - 1; i >= min; i--)
            {
                if (string.IsNullOrEmpty(btns[row, i].Text) || btns[row, i].Text.Length > 1)
                {
                    break;
                }
                else
                {
                    sb.Insert(0, btns[row, i].Text);
                }
            }

            if (sb.ToString().Length > 1)
            {
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
