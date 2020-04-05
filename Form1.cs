using System;
using System.Linq;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        //Store the current players hand at the start of their turn
        Button[] handAtTurnStart;
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
            bh.GenerateBoard(pnlBoard, Button_DragEnter, Button_DragDrop);
            //Add drag and drop functionality to tile hand buttons
            pnlTiles.Controls.OfType<Button>().ToList().ForEach(btn => btn.MouseDown += Button_MouseDown); 
            //
            //MessageBox.Show(WordChecker.checkWord("Test").ToString(), "");
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
    }
}