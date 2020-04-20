using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Game_Modeling
{
    class HandCreator
    {
        static Button[] hand;
        static int TileWidth;
        static int TileHeight;
        const int HorizontalPadding = 2;
        const int VerticalPadding = 20;
        const int HandSize = 7;

        public static Button[] GenerateHand(Panel pnlHand, Action<object, MouseEventArgs> mouseDown)
        {
            TileWidth = (pnlHand.Size.Width / HandSize) - (HorizontalPadding);
            TileHeight = (pnlHand.Size.Height) - (VerticalPadding);
            Size size = new Size(TileWidth, TileHeight);
            Point loc = new Point(0, 0);
            hand = new LetterTile[HandSize];
            //Button Start
            for (int i = 0; i < HandSize; i++)
            {
                loc.Y = (size.Height - 30);

                    hand[i] = new LetterTile()
                    {
                        Location = new Point(i * (size.Width + HorizontalPadding), loc.Y),
                        Size = size,
                        Font = new Font("Arial", 8, FontStyle.Bold),
                        Name = "btnHand" + i.ToString(),
                        Enabled = true,
                        AllowDrop = true
                    };

                //Associates the same event handler with each of the buttons generated
                    hand[i].MouseDown += new MouseEventHandler(mouseDown);
                    // Add button to the form
                    pnlHand.Controls.Add(hand[i]);

                }//One Row Complete 

            return hand;
        }
    }
}
