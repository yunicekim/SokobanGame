using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * The program is to draw board and put various images on the board, 
 * then save the current situation on file
 * 
 * Revision History
 *  Sept 25, 2019 Created by Yunice Kim
 *  
 */
namespace YKimAssignment2
{
    public partial class frmDesign : Form
    {
        //define the rows and columns count for global
        int rowsCount;
        int columnsCount;
        //set the tile type default value(none)
        TileType activeType = TileType.None;

        /// <summary>
        /// initialize the form and set radio buttons for icon as a toolbox
        /// </summary>
        public frmDesign()
        {
            InitializeComponent();

            rdoNone.Tag = TileType.None;
            rdoHero.Tag = TileType.Hero;
            rdoWall.Tag = TileType.Wall;
            rdoBox.Tag = TileType.Box;
            rdoDestination.Tag = TileType.Destination;
        }

        /// <summary>
        /// set the tile the chosen image of the toolbox when one point of the board is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_Click(object sender, EventArgs e)
        {
            Tile tile = (Tile)sender;
            tile.Type = activeType;

            switch (activeType)
            {
                case TileType.None:
                    tile.Image = null; 
                    break;
                case TileType.Hero:
                    tile.Image = imgLst.Images[1];
                    break;
                case TileType.Wall:
                    tile.Image = imgLst.Images[2];
                    break;
                case TileType.Box:
                    tile.Image = imgLst.Images[3];
                    break;
                case TileType.Destination:
                    tile.Image = imgLst.Images[4];
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// set the current tile type to the global variable, activeType of tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton tool = (RadioButton)sender;
            activeType = (TileType)tool.Tag;
        }

        /// <summary>
        /// draw the board as many as the column's and row's number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            pnlGameBoard.Controls.Clear();

            if (int.TryParse(txtRows.Text, out rowsCount) &&
                    int.TryParse(txtColumns.Text, out columnsCount))
            {
                if (rowsCount == 0 || columnsCount == 0)
                {
                    MessageBox.Show("Enter a row or column number");
                }
                else
                {
                    for (int row = 0; row < rowsCount; row++)
                    {
                        for (int column = 0; column < columnsCount; column++)
                        {
                            Tile tile = new Tile(row, column);

                            tile.Click += Tile_Click;

                            pnlGameBoard.Controls.Add(tile);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter row and column size using numbers");
            }
        }

        /// <summary>
        /// save the current board size and all points of the image icons to the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Game Board (*.game)|*.game";
            if (rowsCount == 0 || columnsCount == 0)
            {
                MessageBox.Show("Nothing to save");
            }
            else
            {
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveDlg.FileName))
                    {
                        writer.WriteLine($"{rowsCount}");
                        writer.WriteLine($"{columnsCount}");

                        foreach (Tile tile in pnlGameBoard.Controls)
                        {
                            writer.WriteLine(tile.GetObjectRowData());
                            writer.WriteLine(tile.GetObjectColumnData());
                            writer.WriteLine(tile.GetObjectTypeData());
                        }
                    }
                    MessageBox.Show("File saved successfully");
                }
            }
        }

        /// <summary>
        /// exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
