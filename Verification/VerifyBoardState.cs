using Scrabble.Game_Modeling;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Scrabble.Verification
{
 
    public static class VerifyBoardState { 
        public static string VerifyBoard(Button[,] board, List<int> placements, WordChecker wc, InternalBoard ib)
        {
            StringBuilder sb = new StringBuilder();
            HashSet<string> words = new HashSet<string>();
            
            foreach (int tileIndex in placements)
            {
                
                bool wordCreatedThisTurn = false;
                string horizontalWord;
                string verticalWord;
                //Horizontal Word
                List<int> positions = new List<int>(15);
                horizontalWord = (BoardCheckerHorizontal.CheckHorizontal(board, tileIndex, ib, ref positions));
               
                foreach(int pos in positions)
                {
                    if (wordCreatedThisTurn == true)
                        break;

                    if(TilePlacement.CheckForTurnPlacement(pos, ib))
                    {
                        words.Add(horizontalWord);
                        wordCreatedThisTurn = true;
                    }

                }
                //Vertical Word
                positions = new List<int>(15);
                verticalWord = (BoardCheckerVertical.CheckVertical(board, tileIndex, ib, ref positions));

                foreach (int pos in positions)
                {
                    if (wordCreatedThisTurn == true)
                        break;

                    if (TilePlacement.CheckForTurnPlacement(pos, ib))
                    {
                        words.Add(verticalWord);
                        wordCreatedThisTurn = true;
                    }
                }
            }

            foreach (string word in words)
            {
                if (word.Length < 2)
                    continue;
                if (wc.CheckWord(word))
                {
                    sb.Append(word + " ");
                }
                else
                {
                    sb.Append(word + "! ");
                }
            }
            return sb.ToString();
        }
    }
}
