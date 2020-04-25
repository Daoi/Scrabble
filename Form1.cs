using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Scrabble.Verification;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        bool exchanging = false;
        const int InHand = -1;
        Game currentGame = new Game();
        Player playerOne = new Player("p1");
        Player playerTwo = new Player("p2");
        Player currentPlayer;
        Button[,] gameBoard = new Button[15, 15];
        //Store the current players hand and the board at the start of turn
        Dictionary<LetterTile, string> handAtTurnStart = new Dictionary<LetterTile, string>();
        Dictionary<Button, string> boardAtTurnStart = new Dictionary<Button, string>();
        //The tile currently being manipulated by the player
        LetterTile currentTile;
        int currentTileValue;
        string currentTileLetter;
        List<int> placements = new List<int>();
        //
        WordChecker wc = new WordChecker();

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
            Game_Modeling.HandCreator.GenerateHand(pnlTiles, Button_MouseDown);
            //
            currentPlayer = Game_Rules.TurnOrder.DetermineTurnOrder(playerOne, playerTwo, currentGame);
            playerOne.DrawFirstHand(currentGame);
            playerTwo.DrawFirstHand(currentGame);
            FirstTurn();

            
        }

        //Drag and Drop Functionallity Begin
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            LetterTile letterTile = sender as LetterTile;
            currentTile = letterTile;
            currentTileLetter = letterTile.Text.ToString();
            currentTileValue = Game.getLetterValue(currentTileLetter);
            letterTile.DoDragDrop(letterTile.Text, DragDropEffects.Copy);
            
        }

        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            Button btn = (Button)sender;
            int[] index = BoardHandler.getRowCol(int.Parse(btn.Tag.ToString()));
            if (!TilePlacement.CheckAdjacent(index[0], index[1], 14, 14, gameBoard))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            boardAtTurnStart.Add(btn, btn.Text);
            handAtTurnStart.Add(currentTile, currentTile.Text);
            currentTile.SetBoardPosition(int.Parse(btn.Tag.ToString()));
            btn.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            btn.AllowDrop = false;
            placements.Add(int.Parse(btn.Tag.ToString()));
            currentTile.Text = "";
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            Button btn = sender as Button;
            if(currentTile.Text == " ")
            {

            }
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
            foreach (LetterTile handTile in handAtTurnStart.Keys)
            {
                handTile.Text = handAtTurnStart[handTile];
                handTile.SetBoardPosition(InHand);
            }

            handAtTurnStart = new Dictionary<LetterTile, string>();
            boardAtTurnStart = new Dictionary<Button, string>();
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            string words = Verification.VerifyBoardState.VerifyBoard(gameBoard, placements, wc);
            StringBuilder invalidWords = new StringBuilder("The following invalid words were found: ");

            if (words.Contains("!"))//Turn unsuccesful, inform player of incorrect words.
            {
                string[] split = words.Split(' ');
                foreach (string str in split)
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
                for (int i = 0; i < newTiles.Length; i++)
                {
                    emptyTiles[i].Text = newTiles[i];
                }
                EndTurn();
            }
        }

        public void EndTurn()
        {
            currentPlayer.SaveHand(GetHand());
            SwitchTurn();
            NewTurn();
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
            handAtTurnStart = new Dictionary<LetterTile, string>();
            boardAtTurnStart = new Dictionary<Button, string>();
        }

        private void Button_MouseDownExchange(object sender, MouseEventArgs me)
        {
            LetterTile btn = (LetterTile)sender;
            if(btn.Exchange == false)
            {
                btn.Exchange = true;
                btn.BackColor = System.Drawing.Color.LightSteelBlue;
            }
            else
            {
                btn.Exchange = false;
                btn.BackColor = System.Drawing.SystemColors.Control;
            }

        }



         private void btnExchangeTiles_Click(object sender, EventArgs e)
        {
            resetBoard();
            List<LetterTile> tiles = pnlTiles.Controls.OfType<LetterTile>().ToList();
            
            if (exchanging == true)
            {
                exchanging = false;
                List<LetterTile> exchangeTiles = tiles.FindAll(lt => lt.Exchange == true);
                //No exchange done
                if (exchangeTiles.Count == 0)
                {
                    tiles.ForEach(lt => lt.MouseDown += new MouseEventHandler(Button_MouseDown));
                    tiles.ForEach(lt => lt.MouseDown -= Button_MouseDownExchange);
                    tiles.ForEach(lt => lt.BackColor = System.Drawing.SystemColors.Control);
                    lblExchange.Text = "";
                    btnEndTurn.Enabled = true;
                    btnResetTurn.Enabled = true;
                    return;
                }
                //Draw tiles
                string[] newTiles = currentGame.drawTiles(exchangeTiles.Count);
                for (int i = 0; i < newTiles.Length; i++)
                {
                    exchangeTiles[i].Text = newTiles[i];
                }
                tiles.ForEach(lt => lt.MouseDown += new MouseEventHandler(Button_MouseDown));
                tiles.ForEach(lt => lt.MouseDown -= Button_MouseDownExchange);
                tiles.ForEach(lt => lt.Exchange = false);
                exchanging = false;
                btnEndTurn.Enabled = true;
                btnResetTurn.Enabled = true;
                MessageBox.Show($"{currentPlayer.GetName()} has used their turn to exchange tiles. It is now {(currentPlayer == playerOne ? playerTwo.GetName() : playerOne.GetName())}'s turn.");
                tiles.ForEach(lt => lt.BackColor = System.Drawing.SystemColors.Control);
                EndTurn();
                lblExchange.Text = "";

            }
            else
            {
                exchanging = true;
                btnEndTurn.Enabled = false;
                btnResetTurn.Enabled = false;
                tiles.ForEach(lt => lt.MouseDown += new MouseEventHandler(Button_MouseDownExchange));
                tiles.ForEach(lt => lt.MouseDown -= Button_MouseDown);
                lblExchange.Text = "Exchange Mode Active. \r\n" +
                                    "To exchange tiles click the ones you want to switch out \r\n " +
                                    "Then, once you're done, click exchange again to switch them. \r\n " +
                                    "If you change your mind about a tile, click it again to unseslect it. \r\n" +
                                    "Selected tiles will turn blue. Exchanging tiles will end your turn.";
            }
       }
    }
}