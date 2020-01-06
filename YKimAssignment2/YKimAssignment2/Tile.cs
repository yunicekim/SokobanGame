using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace YKimAssignment2
{
    enum TileType
    {
        None,
        Hero,
        Wall,
        Box,
        Destination
    }

    class Tile : Button
    {
        int row;
        int col;

        const int TILE_SIZE = 50;
        const int OFFSET = 20;

        public TileType Type { get; set; }

        public Tile(int row, int col)
        {
            this.row = row;
            this.col = col;
            Type = TileType.None;

            this.Size = new Size(TILE_SIZE, TILE_SIZE);

            int x = OFFSET + (col * TILE_SIZE);
            int y = OFFSET + (row * TILE_SIZE);

            this.Location = new Point(x, y);
        }

        public string GetObjectRowData()
        {
            return $"{row}";
        }
        public string GetObjectColumnData()
        {
            return $"{col}";
        }
        public string GetObjectTypeData()
        {
            return $"{(int)Type}";
        }
    }
}
