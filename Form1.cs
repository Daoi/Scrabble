using System;
using System.Linq;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Form1 : Form
    {
        Button[] currentHand;
        Button currentTile;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BoardHandler bh = new BoardHandler();
            bh.GenerateBoard(pnlBoard, Button_DragEnter, Button_DragDrop);
            pnlTiles.Controls.OfType<Button>().ToList().ForEach(btn => btn.MouseDown += Button_MouseDown); 
            MessageBox.Show(WordChecker.checkWord("Test").ToString(), "");
        }

        //Drag and Drop Functionallity Begin
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            currentTile = btn;
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