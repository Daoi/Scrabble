using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Verification
{
    public static class VerifyBoardState
    {
        public static string VerifyBoard(Button[,] board, List<int> placements)
        {
            StringBuilder sb = new StringBuilder();
            HashSet<string> words = new HashSet<string>();
            foreach (int tileIndex in placements)
            {
                words.Add(BoardCheckerHorizontal.CheckHorizontal(board, tileIndex));
                words.Add(BoardCheckerVertical.CheckVertical(board, tileIndex));
            }

            foreach (string word in words)
            {
                if (word.Length < 2)
                    continue;

                if (WordChecker.CheckWord(word))
                {
                    sb.Append(word + "! ");
                }
                else
                {
                    sb.Append(word + " ");
                }
            }
            return sb.ToString();
        }
    }
}
