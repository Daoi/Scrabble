using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scrabble.Game_Modeling;
using Scrabble.Verification;
using Scrabble.Utility.MsgBox;
using Scrabble.Game_Mechanics.Scoring;
using IronPython.Compiler.Ast;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        InternalBoard ib = new InternalBoard();
        bool exchanging = false;
        const int InHand = -1;
        int score = 0;
        int scoreMultiplier = 1;
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
        List<string> tilesThisTurn = new List<string>();
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
        //Grabbing a tile
        //Drag and Drop Functionallity Begin
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            LetterTile letterTile = sender as LetterTile;
            currentTile = letterTile;
            currentTileLetter = letterTile.Text;
            //MessageBox.Show(currentTileLetter);
            currentTileValue = Game.getLetterValue(currentTileLetter);
            letterTile.DoDragDrop(letterTile.Text, DragDropEffects.Copy);
            
        }
        //Dropping letter on board
        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            bool blankTile = false;
            Button btn = (Button)sender;//The tile the letter is being placed on
            int[] index = BoardHandler.getRowCol(int.Parse(btn.Tag.ToString()));
            
            //Make sure an adjacent tile contains a letter or is the center piece
            if (!TilePlacement.CheckAdjacent(index[0], index[1], gameBoard))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            //Save premodified values
            boardAtTurnStart.Add(btn, btn.Text);
            handAtTurnStart.Add(currentTile, currentTile.Text);
            
            if(currentTile.Text == " ")
            {
                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res = InputBox.ShowDialog("Select a letter for your tile:",
                "Select a letter",   //Text message (mandatory), Title (optional)
                InputBox.Icon.Information, //Set icon type (default info)
                InputBox.Buttons.Ok, //Set buttons (default ok)
                InputBox.Type.ComboBox, //Set type (default nothing)
                new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                               "N", "O", "P", "Q", "R","S", "T", "U", "V", "W", "X", "Y", "Z"}, //String field as ComboBox items (default null)
                false, //Set visible in taskbar (default false)
                new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); //Set font (default by system)
                currentTile.SetTileLetter(InputBox.ResultValue);
                blankTile = true;
            }
            
            //If it's a preimum board tile, record the multiplier
            if (btn.Text.Equals("Double Word Score") || btn.Text.Equals("*"))
            {
                scoreMultiplier *= 2;
            }
            else if (btn.Text.Equals("Triple Word Score"))
            {
                scoreMultiplier *= 3;
            }
            //Calculate value for premium tiles
            score += CalculateScore.CaluclatePlacedTileScore(btn, currentTile);
            tilesThisTurn.Add(currentTile.Text);

            //Potentially useless
            currentTile.SetBoardPosition(int.Parse(btn.Tag.ToString()));
            //Update board tile
            ib.addTile(new LetterTile(currentTile.Text, currentTile.GetBoardPosition()));
            
            if (blankTile)
                btn.Text = currentTile.Text;
            else
                btn.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            
            btn.AllowDrop = false;
            placements.Add(int.Parse(btn.Tag.ToString()));
            currentTile.Text = "";
        }
        //Dragging over a tile
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
            ResetBoard();
        }

        private void ResetBoard()
        {
            score = 0;
            scoreMultiplier = 1;
            tilesThisTurn.Clear();
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
            string words = VerifyBoardState.VerifyBoard(gameBoard, placements, wc, ib);
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
                List<char> letters = words.ToList();
                //Scoring
                foreach (string s in tilesThisTurn)
                {
                    letters.Remove(char.Parse(s));

                }
                letters.ForEach(c =>
                { if (char.IsLetter(c)) {
                        score += CalculateScore.CalculateNonPlacedTileScore(c);
                    }; 
                });
                
                currentPlayer.updateScore(score * scoreMultiplier);

                MessageBox.Show("The following words were formed: " + words + $" For {score * scoreMultiplier} points", "Words formed and score");
                
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
            //Clear Tracking
            tilesThisTurn.Clear();
            //Update Scores
            lblPlayerOneScore.Text = playerOne.PlayerScore.ToString();
            lblPlayerOneScore.Text = playerTwo.PlayerScore.ToString();
            scoreMultiplier = 1;
            score = 0;
            //Save Player Hand
            currentPlayer.SaveHand(GetHand());
            //Update IB
            ib.endTurnIB();
            //
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
            ResetBoard();
            List<LetterTile> tiles = pnlTiles.Controls.OfType<LetterTile>().ToList();
            
            if (exchanging == true)
            {
                exchanging = false;
                List<LetterTile> exchangeTiles = tiles.FindAll(lt => lt.Exchange == true);
                //No exchange done
                if (exchangeTiles.Count == 0)
                {
                    tiles.ForEach(lt => lt.MouseDown -= Button_MouseDownExchange);
                    //tiles.ForEach(lt => lt.MouseDown += new MouseEventHandler(Button_MouseDown));
                    tiles.ForEach(lt => lt.BackColor = System.Drawing.SystemColors.Control);
                    lblExchange.Text = "";
                    btnEndTurn.Enabled = true;
                    btnResetTurn.Enabled = true;
                    return;
                }
                //Draw tiles
                List<LetterTile> newTiles = currentGame.exchangeTiles(exchangeTiles.Count, exchangeTiles);
                for (int i = 0; i < newTiles.Count; i++)
                {
                    exchangeTiles[i].SetTileLetter(newTiles[i].Text);
                }
                tiles.ForEach(lt => lt.MouseDown -= Button_MouseDownExchange);
                //tiles.ForEach(lt => lt.MouseDown += new MouseEventHandler(Button_MouseDown));
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