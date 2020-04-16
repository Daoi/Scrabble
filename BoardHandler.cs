using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scrabble
{
    internal class BoardHandler
    {
        static Button[,] board;
        static int cardCellWidth;
        static int cardCellHeight;
        const int padding = 1;
        const int boardDimensions = 15; //X by X board size
        static Color boardColor = ColorTranslator.FromHtml("#C3BCA0");
        //Selects the first true result based on key function and returns that keys value - 'Double Letter Score' is mostly just manually setting indexes
        //Why? For the same reason I'm making Scrabble in a windows form app, I'm a moron
        Dictionary<Func<int, bool>, string> specialTiles = new Dictionary<Func<int, bool>, string>()
        {
        {x => x == 112, "*" },//Center tile
        {x => x % 7 == 0 && (x / 15 == 0 || x / 15 == 14 || x / 15 == 7) && x != 112, "Triple Word Score" }, //All the triple word score tiles follow x % 7 = 0, then we select the rows those tiles are in.
        {x => x % 15 == x / 15 && ((x / 15 <= 13 && x / 15 >= 10) ||(x / 15 <= 4 && x / 15 >= 1)), "Double Word Score" },//Top left to bottom right diag indexes are equal, then select rows
        {x => x % 15 + x / 15 == 14 && ((x / 15 <= 13 && x / 15 >= 10) ||(x / 15 <= 4 && x / 15 >= 1)), "Double Word Score" },//Bottom left to top right diags sum to 14, then we select rows
        {x => (x % 15 == 9 || x % 15 == 5) && (x / 15 == 1 || x / 15 == 5 || x / 15 == 9 || x / 15 == 13), "Triple Letter Score"},//Triple letter score tiles are in the 5th or 9th col index, then select rows.
        {x => (x % 15 == 1 || x % 15 == 13) && (x / 15 == 5 || x / 15 == 9), "Triple Letter Score"},//Triple letter score tiles are in the 1st or 13th col index, then select rows
        {x => SetDoubleLetterScores(x), "Double Letter Score" },
        {x => x /1 == x, "" }//Regular tiles
        };

        Dictionary<string, Color> tileColors = new Dictionary<string, Color>()
        {
            {"Triple Word Score", Color.OrangeRed},
            {"Double Word Score", Color.LightPink},
            {"Triple Letter Score", Color.LightSteelBlue},
            {"Double Letter Score", Color.LightBlue},
            {"", boardColor},
            {"*", Color.LightPink}
        };



        public Button[,] GenerateBoard(Panel pnlBoard, Action<object, DragEventArgs> dragEnter, Action<object, DragEventArgs> dragDrop)
        {
            cardCellWidth = (pnlBoard.Size.Width / boardDimensions) - (padding);
            cardCellHeight = (pnlBoard.Size.Height / boardDimensions) - (padding);
            Size size = new Size(cardCellWidth, cardCellHeight);
            Point loc = new Point(0, 0);
            board = new Button[boardDimensions, boardDimensions];
            //Button Start
            for (int row = 0; row < boardDimensions; row++)
            {
                loc.Y = row * (size.Height + padding);

                for (int col = 0; col < boardDimensions; col++)
                {
                    board[row, col] = new Button
                    {
                        Location = new Point(col * (size.Width + padding), loc.Y),
                        Size = size,
                        Font = new Font("Arial", 8, FontStyle.Bold),
                        Name = "btn" + row.ToString() + col.ToString(),
                        Tag = getTileValue(row, col).ToString(),
                        Enabled = true,
                        AllowDrop = true
                    };

                    var key = specialTiles.Keys.First(tileValue => tileValue(getTileValue(row, col)));

                    if (specialTiles.ContainsKey(key))
                    {
                        board[row, col].Text = specialTiles[key];
                    }
                    
                    //Associates the same event handler with each of the buttons generated
                    board[row, col].DragEnter += new DragEventHandler(dragEnter);
                    board[row, col].DragDrop += new DragEventHandler(dragDrop);
                    // Add button to the form
                    pnlBoard.Controls.Add(board[row, col]);

                }//One Row Complete 
            }//Done
            
            //Colors
            foreach (Button btn in board)
            {
                if (tileColors.ContainsKey(btn.Text))
                {
                    btn.BackColor = tileColors[btn.Text];
                }
            }
            return board;
        }
            
        private static bool SetDoubleLetterScores(int tile)
        {
            int[] doubleLetterTiles = { 3, 11, 36, 38, 45, 52, 59, 92, 96, 98, 102, 108, 116,
                                       122, 126, 128, 132, 165, 172, 179, 186, 188, 213, 221 };
            return doubleLetterTiles.Contains(tile);
        }





        private static int getTileValue(int row, int col) { return (row * 15) + col; }
        public static int[] getRowCol(int tileIndex){return new int[2]{ tileIndex / 15, tileIndex % 15 };}
    }
}