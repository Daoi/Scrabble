using System.Windows.Forms;

namespace Scrabble
{
    public class Player
    {

        private string name;
        private string[] currentHand;
        private int score;
        private int words;
        private int turns;


        public Player(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SaveHand(string[] hand)
        {
            currentHand = hand;
        }
        
        public string[] GetHand()
        {
            return currentHand;
        }

        public void DrawFirstHand(Game game)
        {
            currentHand = game.drawTiles(7);
        }
    }
}