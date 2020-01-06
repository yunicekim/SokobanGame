using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YKimAssignment2
{

    class PicBoxTile : PictureBox
    {
        int row;
        int col;

        const int TILE_SIZE = 50;
        const int OFFSET = 20;

        public TileType Type{ get; set; }

        public PicBoxTile(int row, int col)
        {
            this.row = row;
            this.col = col;
            Type = TileType.None;

            this.Size = new Size(TILE_SIZE, TILE_SIZE);

            int x = OFFSET + (col * TILE_SIZE);
            int y = OFFSET + (row * TILE_SIZE);

            this.Location = new Point(x, y);
        }

        public struct Position
        {
            public int X { get; }
            public int Y { get; }

            public Position(int x, int y)
            {
                if (x < -1 || y < -1)
                {
                    throw new ArgumentException("X and Y must be greater than -1");
                }
                else
                {
                    X = x;
                    Y = y;
                }
            }

            public override string ToString()
            {
                return $"{X}, {Y}";
            }
        }
    }
}
