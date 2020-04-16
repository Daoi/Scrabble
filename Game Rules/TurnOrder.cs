using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Game_Rules
{
    public static class TurnOrder
    {
        public static Player DetermineTurnOrder(Player playerOne, Player playerTwo, Game currentGame)
        {
            Player result = new Player("");
            string firstTile = currentGame.drawTiles(1)[0];
            string secondTile = currentGame.drawTiles(1)[0];
            currentGame.addTiles(new string[2] { firstTile, secondTile });

            if (firstTile.ToCharArray()[0] - 64 < secondTile.ToCharArray()[0] - 64)
            {
                if (firstTile == " ") firstTile = "the blank tile";
                MessageBox.Show($"{playerOne.GetName()} drew {firstTile}, {playerTwo.GetName()} drew {secondTile}. {playerOne.GetName()} will go first.", "Turn Order");
                result = playerOne;
            }
            else if (firstTile.ToCharArray()[0] - 64 > secondTile.ToCharArray()[0] - 64)
            {
                if (secondTile == " ") secondTile = "the blank tile";
                MessageBox.Show($"{playerOne.GetName()} drew {firstTile}, {playerTwo.GetName()} drew {secondTile}. {playerTwo.GetName()} will go first.", "Turn Order");
                result = playerTwo;
            }
            else if (firstTile.ToCharArray()[0] - 64 == secondTile.ToCharArray()[0] - 64)
            {
                MessageBox.Show($"Players drew the same letter, {playerOne.GetName()} will go first", "Turn Order");
                result = playerOne;
            }

            return result;
        }
    }
}
