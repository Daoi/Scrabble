using System;
using System.Collections;
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
        const int padding = 2;
        const int boardDimensions = 15; //X by X board size
        static Color boardColor = ColorTranslator.FromHtml("#C3BCA0");
        //Selects the first true result based on key function and returns that keys value - 'Double Letter' is mostly harded coded
        //Why? For the same reason I'm making Scrabble in a windows form app, I'm a moron
        Dictionary<Func<int, bool>, string> specialTiles = new Dictionary<Func<int, bool>, string>()
        {
        {x => x == 112, "*" },//Center tile
        {x => x % 7 == 0 && (x / 15 == 0 || x / 15 == 14 || x / 15 == 7) && x != 112, "Triple Word Score" }, //All the triple word score tiles follow x % 7 = 0, then we select the rows those tiles are in.
        {x => x % 15 == x / 15 && ((x / 15 <= 13 && x / 15 >= 10) ||(x / 15 <= 4 && x / 15 >= 1)), "Double Word Score" },//Top left to bottom right diag indexes are equal, then select rows
        {x => x % 15 + x / 15 == 14 && ((x / 15 <= 13 && x / 15 >= 10) ||(x / 15 <= 4 && x / 15 >= 1)), "Double Word Score" },//Bottom left to top right diags sum to 14, then we select rows
        {x => (x % 15 == 9 || x % 15 == 5) && (x / 15 == 1 || x / 15 == 5 || x / 15 == 9 || x / 15 == 13), "Triple Letter Score"},//Triple letter score tiles are in the 5th or 9th col index, then select rows.
        {x => (x % 15 == 1 || x % 15 == 13) && (x / 15 == 5 || x / 15 == 9), "Triple Letter Score"},//Triple letter score tiles are in the 1st or 13th col index, then select rows
        {x => x - 10 == 112 || x - 20 == 112 || x + 10 == 112 || x + 20 == 112 || x + 14 == 112 || x + 16 == 112 || x - 14 == 112 || x - 16 == 112, "Double Letter Score" },//Distance from center
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



        public Button[,] GenerateBoard(Panel pnlBoard, Action<object, EventArgs> mouseClick)
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
                        Enabled = true
                    };

                    var key = specialTiles.Keys.First(tileValue => tileValue(getTileValue(row, col)));

                    if (specialTiles.ContainsKey(key))
                    {
                        board[row, col].Text = specialTiles[key];
                    }
                    
                    //Associates the same event handler with each of the buttons generated
                    board[row, col].MouseClick += new MouseEventHandler(mouseClick);
                    // Add button to the form
                    pnlBoard.Controls.Add(board[row, col]);

                }//One Row Complete 
            }//Done

            foreach (Button btn in board)
            {
                //Double Letter Score Tiles
                int tileValue = int.Parse(btn.Tag.ToString());
                if (SetDoubleLetterScores(tileValue))
                {
                    btn.Text = "Double Letter Score";
                }
                //Colors
                if (tileColors.ContainsKey(btn.Text))
                {
                    btn.BackColor = tileColors[btn.Text];
                }
            }
            return board;
        }

        private int getTileValue(int row, int col)
        {

            return (row * 15) + col;
        }

        private static bool SetDoubleLetterScores(int tile)
        {
            int row = tile / 15;
            int col = tile % 15;
            //Check if the tile is within 3 of a Triple Word score forward, backwards, up, or down

            ArrayList neighbors = getNeighbors(row, col, boardDimensions - 1, boardDimensions - 1);
            
            foreach (int[] cords in neighbors)
            {
                if (board[cords[0], cords[1]].Text == "Triple Word Score")
                    return true;
            }

            return false;
       

        }

        private static ArrayList getNeighbors(int x, int y, int maxX, int maxY)
        {
            ArrayList neighbors = new ArrayList();
            if (x > 7)
            {
                if (x - 4 >= 0)
                    neighbors.Add(new int[] { x - 4, y });
            }
            if (x < 7)
            {
                if (x + 4 <= maxX)
                    neighbors.Add(new int[] { x + 4, y });
            }
            if (y < 7)
            {
                if (y - 3 >= 0)
                    neighbors.Add(new int[] { x, y - 3 });
            }
            if (y > 7)
            {
                if (y + 3 <= maxY)
                    neighbors.Add(new int[] { x, y + 3 });
            }

            return neighbors;

        }
    }
}