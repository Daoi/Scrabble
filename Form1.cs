using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        Game currentGame = new Game();
        Player playerOne = new Player("p1");
        Player playerTwo = new Player("p2");
        //Store the current players hand and the board at the start of turn
        ArrayList handAtTurnStart;
        ArrayList boardAtTurnStart;
        Button[,] gameBoard;
        //The tile currently being manipulated by the player
        Button currentTile;
        int currentTileValue;
        string currentTileLetter;
        //

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create the board
            BoardHandler bh = new BoardHandler();
            gameBoard = bh.GenerateBoard(pnlBoard, Button_DragEnter, Button_DragDrop);
            
            //Add drag and drop functionality to tile hand buttons
            pnlTiles.Controls.OfType<Button>().ToList().ForEach(btn => btn.MouseDown += Button_MouseDown);
            //
            //MessageBox.Show(WordChecker.checkWord("Test").ToString(), "");
            DetermineTurnOrder();
            boardAtTurnStart = SaveState(pnlBoard);
            MessageBox.Show("Derp");
            
        }

        //Drag and Drop Functionallity Begin
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            currentTile = btn;
            currentTileLetter = btn.Text;
            currentTileValue = LetterTiles.getLetterValue(currentTileLetter);
            btn.DoDragDrop(btn.Text, DragDropEffects.Copy);
            
        }

        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            btn.AllowDrop = false;
            currentTile.Text = "";

        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            Button btn = sender as Button;
            string tileValue = currentTile.Text;
            if (e.Data.GetDataPresent(DataFormats.StringFormat) && tileValue != "")
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }
        //Drag and Drop funtionallity End

        public void DetermineTurnOrder()
        {
            string firstTile = currentGame.drawTiles(1)[0];
            string secondTile = currentGame.drawTiles(1)[0];
            currentGame.addTiles(new string[2] { firstTile, secondTile });

            if (firstTile.ToCharArray()[0] - 64 < secondTile.ToCharArray()[0] - 64)
            {
                if (firstTile == " ") firstTile = "the blank tile";
                MessageBox.Show($"{playerOne.getName()} drew {firstTile}, {playerTwo.getName()} drew {secondTile}. {playerOne.getName()} will go first.", "Turn Order");
            }
            else if (firstTile.ToCharArray()[0] - 64 > secondTile.ToCharArray()[0] - 64)
            {
                if (secondTile == " ") secondTile = "the blank tile";
                MessageBox.Show($"{playerOne.getName()} drew {firstTile}, {playerTwo.getName()} drew {secondTile}. {playerTwo.getName()} will go first.", "Turn Order");
            }
            else if (firstTile.ToCharArray()[0] - 64 == secondTile.ToCharArray()[0] - 64)
            {
                MessageBox.Show($"Players drew the same letter, {playerOne.getName()} will go first", "Turn Order");
            }
        }

        public ArrayList SaveState(Panel pnl)
        {
            ArrayList values = new ArrayList();
            pnl.Controls.OfType<Button>().ToList().ForEach(btn => values.Add(btn.Text));
            return values;
        }

        private void btnResetTurn_Click(object sender, EventArgs e)
        {
            List<Button> boardTiles = pnlBoard.Controls.OfType<Button>().ToList();
            List<Button> handTiles = pnlTiles.Controls.OfType<Button>().ToList();
            for (int i = 0; i < boardAtTurnStart.Count; i++)
            {
                boardTiles[i].Text = boardAtTurnStart[i].ToString();
            }
            for (int i = 0; i < handAtTurnStart.Count; i++)
            {
                boardTiles[i].Text = handAtTurnStart[i].ToString();
            }
        }
    }
}