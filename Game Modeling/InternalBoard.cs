using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Game_Modeling
{
    public class InternalBoard
    {
        List<LetterTile> internalBoard = new List<LetterTile>(225);
        public InternalBoard()
        {
            for(int i = 0; i < internalBoard.Capacity - 1; i++)
            {
                internalBoard.Add(new LetterTile());
            }
        }

        public void addTile(LetterTile tile)
        {
            int pos = tile.GetBoardPosition();
            internalBoard.Insert(pos, tile);
        }

        public void endTurnIB()
        {
            foreach(LetterTile lt in internalBoard)
            {
                lt.PlacedThisTurn = false;
            }
        }

        public List<LetterTile> Board { get { return this.internalBoard; } }


    }
}
