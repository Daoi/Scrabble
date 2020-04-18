using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Game currentGame = new Game();
        Player playerOne = new Player("p1");
        Player playerTwo = new Player("p2");
        Player currentPlayer;
        Button[,] gameBoard = new Button[15, 15];
        //Store the current players hand and the board at the start of turn
        Dictionary<Button, string> handAtTurnStart = new Dictionary<Button, string>();
        Dictionary<Button, string> boardAtTurnStart = new Dictionary<Button, string>();
        //The tile currently being manipulated by the player
        Button currentTile;
        int currentTileValue;
        string currentTileLetter;
        List<int> placements = new List<int>();
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
            currentPlayer = Game_Rules.TurnOrder.DetermineTurnOrder(playerOne, playerTwo, currentGame);
            playerOne.DrawFirstHand(currentGame);
            playerTwo.DrawFirstHand(currentGame);
            FirstTurn();

            
        }

        //Drag and Drop Functionallity Begin
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            currentTile = btn;
            currentTileLetter = btn.Text.ToString();
            currentTileValue = Game.getLetterValue(currentTileLetter);
            btn.DoDragDrop(btn.Text, DragDropEffects.Copy);
            
        }

        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            Button btn = (Button)sender;
            int[] index = BoardHandler.getRowCol(int.Parse(btn.Tag.ToString()));
            if (!Verification.TilePlacement.CheckAdjacent(index[0], index[1], 14, 14, gameBoard))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            boardAtTurnStart.Add(btn, btn.Text);
            handAtTurnStart.Add(currentTile, currentTile.Text);
            btn.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            btn.AllowDrop = false;
            placements.Add(int.Parse(btn.Tag.ToString()));
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
        
        //Move to Game class probably



        private void btnResetTurn_Click(object sender, EventArgs e)
        {
            resetBoard();
        }

        private void resetBoard()
        {
            foreach (Button boardTile in boardAtTurnStart.Keys)
            {
                boardTile.Text = boardAtTurnStart[boardTile];
                boardTile.AllowDrop = true;
            }
            foreach (Button handTile in handAtTurnStart.Keys)
            {
                handTile.Text = handAtTurnStart[handTile];
            }

            handAtTurnStart = new Dictionary<Button, string>();
            boardAtTurnStart = new Dictionary<Button, string>();
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            string words = Verification.VerifyBoardState.VerifyBoard(gameBoard, placements);
            StringBuilder invalidWords = new StringBuilder("The following invalid words were found: ");

            if (words.Contains("!"))//Turn unsuccesful, inform player of incorrect words.
            {
                string[] split = words.Split(' ');
                foreach(string str in split)
                {
                    if (str.Contains("!"))
                    {
                        invalidWords.Append(str.TrimEnd('!') + " ");
                    }
                }

                MessageBox.Show(invalidWords.ToString() + " please retake your turn.");
            }
            else//Turn succuesful, draw new tiles and save hand. Calculate Score. 
            {
                MessageBox.Show("The following words were formed: " + words, "Words formed and score");
                List<Button> emptyTiles = pnlTiles.Controls.OfType<Button>().ToList().FindAll(btn => btn.Text.Equals(""));
                string[] newTiles = currentGame.drawTiles(emptyTiles.Count);
                for(int i = 0; i < newTiles.Length; i++)
                {
                    emptyTiles[i].Text = newTiles[i];
                }
                
                currentPlayer.SaveHand(GetHand());
                SwitchTurn();
                NewTurn();
            
            }

        }

        public void FirstTurn()
        {
            UpdateHand(currentPlayer.GetHand());
            lblCurrentPlayersTurn.Text = $"It is {currentPlayer.GetName()}'s turn";

        }

        public void SwitchTurn()
        {
            if (currentPlayer == playerOne)
            {
                currentPlayer = playerTwo;
            }
            else
            {
                currentPlayer = playerOne;
            }

            UpdateHand(currentPlayer.GetHand());
            lblCurrentPlayersTurn.Text = $"It is {currentPlayer.GetName()}'s turn";

        }

        public void UpdateHand(string[] hand)
        {
            List<Button> handTiles = pnlTiles.Controls.OfType<Button>().ToList();
            for(int i = 0; i < handTiles.Count; i++)
            {
                handTiles[i].Text = hand[i];
            }

        }

        public string[] GetHand()
        {
            List<string> hand = new List<string>();
            pnlTiles.Controls.OfType<Button>().ToList().ForEach(btn => hand.Add(btn.Text));
            return hand.ToArray<string>();
        }

        public void NewTurn()
        {
            handAtTurnStart = new Dictionary<Button, string>();
            boardAtTurnStart = new Dictionary<Button, string>();
        }
    }
}