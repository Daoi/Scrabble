using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Verification
{
    public static class BoardCheckerVertical
    {
        public static string CheckVertical(Button[,] btns, int tileIndex)
        {
            StringBuilder sb = new StringBuilder();
            int[] indicies = BoardHandler.getRowCol(tileIndex);
            int row = indicies[0];
            int col = indicies[1];
            int max = 14, min = 0;
            //Down
            for (int i = row; i < max; i++)
            {
                if (string.IsNullOrEmpty(btns[i, col].Text) || btns[i, col].Text.Length > 1)
                {
                    break;
                }
                else
                {
                    sb.Append(btns[i, col].Text);
                }
            }
            //Up
            for (int i = row - 1; i >= min; i--)
            {
                if (string.IsNullOrEmpty(btns[i, col].Text) || btns[i, col].Text.Length > 1)
                {
                    break;
                }
                else
                {
                    sb.Insert(0, btns[i, col].Text);
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
