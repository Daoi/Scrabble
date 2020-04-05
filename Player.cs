using System.Windows.Forms;

namespace Scrabble
{
    internal class Player
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

        public string getName()
        {
            return name;
        }
    }
}